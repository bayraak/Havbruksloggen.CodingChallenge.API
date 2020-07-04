using System;
using Havbruksloggen.CodingChallenge.Core;
using Havbruksloggen.CodingChallenge.Core.Models;

namespace Havbruksloggen.CodingChallenge.Api.IntegrationTests.Infrastructure
{
    public class EmployeesContextDataFeeder
    {
        public static void Feed(ApplicationDbContext dbContext)
        {
          dbContext.Employees.Add(new Employee
            {
                EmpNo = 1,
                FirstName = "Thomas",
                LastName = "Anderson",
                BirthDate = new DateTime(1962, 03, 11)
            });

            dbContext.Employees.Add(new Employee
            {
                EmpNo = 2,
                FirstName = "Jonathan",
                LastName = "Fountain",
                BirthDate = new DateTime(1954, 07, 19)
            });

            dbContext.Employees.Add(new Employee
            {
                EmpNo = 99,
                FirstName = "Person",
                LastName = "ToDelete",
                BirthDate = new DateTime(2019, 10, 13)
            });

            dbContext.SaveChanges();
        }
    }
}
