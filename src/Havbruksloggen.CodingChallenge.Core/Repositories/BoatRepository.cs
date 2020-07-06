using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havbruksloggen.CodingChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
#nullable enable

namespace Havbruksloggen.CodingChallenge.Core.Repositories
{
    public interface IBoatRepository
    {
        Task<IEnumerable<Boat>> GetAllAsync(CancellationToken cancellationToken, int userId);

        Task Create(Boat user);

        Task<Boat>? GetById(int id);
    }

    public class BoatRepository : RepositoryBase<Boat, ApplicationDbContext>, IBoatRepository
    {
        public BoatRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }


        public async Task<IEnumerable<Boat>> GetAllAsync(CancellationToken cancellationToken, int userId)
        {
            return await DbContext.Boats
                .AsNoTracking()
                .Include(s => s.CrewMembers)
                .Include(p => p.User)
                .Where(q => q.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task<Boat>? GetById(int id)
        {
            return await DbContext.Boats.FindAsync(id);
        }

        public async Task Create(Boat boat)
        {
            await DbContext.AddAsync(boat);
            await DbContext.SaveChangesAsync();
        }
    }
}
