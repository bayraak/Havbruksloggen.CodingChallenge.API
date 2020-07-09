using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havbruksloggen.CodingChallenge.Core.Dtos;
using Havbruksloggen.CodingChallenge.Core.Entities;
using Havbruksloggen.CodingChallenge.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Havbruksloggen.CodingChallenge.Core.Repositories
{
    public interface IBoatRepository
    {
        Task<IEnumerable<Boat>> GetAllAsync(CancellationToken cancellationToken, int userId);

        Task Create(Boat user);

        Task<Boat>? GetById(int id);

        Task<Boat>? AddCrewMembersToBoat(int boatId, ICollection<CreateCrewMemberDto> crewMembers, int userId);
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

        public async Task<Boat>? AddCrewMembersToBoat(int boatId, ICollection<CreateCrewMemberDto> crewMembers, int userId)
        {

            var entity = await DbContext.Boats.FirstOrDefaultAsync(p => p.Id == boatId);

            if (entity is null) return null;

            if (entity.UserId != userId) throw new UnauthorizedAccessException();

            entity.CrewMembers = crewMembers.ToEntities();
            await DbContext.SaveChangesAsync();

            var updatedEntity = await DbContext.Boats.FirstOrDefaultAsync(p => p.Id == boatId);
            return updatedEntity;
        }
    }
}
