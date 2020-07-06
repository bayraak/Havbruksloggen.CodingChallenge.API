using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Havbruksloggen.CodingChallenge.Core.Dtos;
using Havbruksloggen.CodingChallenge.Core.Extensions;
using Havbruksloggen.CodingChallenge.Core.Entities;

namespace Havbruksloggen.CodingChallenge.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<EmployeeDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<EmployeeDetailsDto> GetByIdWithDetailsAsync(object id, CancellationToken cancellationToken);
        Task<EmployeeDto> GetOldestAsync(CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
        Task<EmployeeDto> InsertAsync(EmployeePostDto employeePostDto, CancellationToken cancellationToken);
        Task<EmployeeDto> UpdateAsync(int id, EmployeePutDto employeePutDto, CancellationToken cancellationToken);
    }

    public class EmployeeRepository : RepositoryBase<Employee, ApplicationDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var employees = await DbContext.Employees
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return employees.Select(EmployeeExtensions.MapToDto).ToList();
        }

        public async Task<EmployeeDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var emp = await DbContext.Employees
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.EmpNo == id);
            if (emp == null)
            {
                return null;
            }

            return emp.MapToDto();
        }

        public async Task<EmployeeDetailsDto> GetByIdWithDetailsAsync(object id, CancellationToken cancellationToken)
        {
            var emp = await DbContext.Employees
                .SingleOrDefaultAsync(x => x.EmpNo == (int)id, cancellationToken);
            if (emp == null)
            {
                return null;
            }

            return new EmployeeDetailsDto
            {
                Id = emp.EmpNo,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                BirthDate = emp.BirthDate,
            };
        }

        public async Task<EmployeeDto> GetOldestAsync(CancellationToken cancellationToken)
        {
            var emp = await DbContext.Employees
                .OrderBy(x => x.BirthDate)
                .FirstOrDefaultAsync(cancellationToken);
            if (emp == null)
            {
                return null;
            }

            return emp.MapToDto();
        }

        public async Task<EmployeeDto> InsertAsync(EmployeePostDto employeePostDto, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = employeePostDto.FirstName,
                LastName = employeePostDto.LastName,
                BirthDate = employeePostDto.BirthDate.Value
            };

            await DbContext.Employees.AddAsync(employee, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);

            return employee.MapToDto();
        }

        public async Task<EmployeeDto> UpdateAsync(int id, EmployeePutDto employeePutDto, CancellationToken cancellationToken)
        {
            var emp = await DbContext.Employees
                .SingleOrDefaultAsync(x => x.EmpNo == id);
            if (emp is null)
            {
                return null;
            }

            emp.LastName = employeePutDto.LastName;

            await DbContext.SaveChangesAsync(cancellationToken);

            return emp.MapToDto();
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            var emp = await DbContext.Employees
                .SingleOrDefaultAsync(x => x.EmpNo == id);
            if (emp == null)
            {
                return false;
            }

            DbContext.Employees.Remove(emp);
            return await DbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
