using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Havbruksloggen.CodingChallenge.Core.Dtos;
using Havbruksloggen.CodingChallenge.Core.Entities;
using Havbruksloggen.CodingChallenge.Core.Extensions;
using Havbruksloggen.CodingChallenge.Core.Repositories;
#nullable enable

namespace Havbruksloggen.CodingChallenge.Core.Services
{
    public interface IBoatService
    {
        Task<IEnumerable<BoatDto>> GetAllAsync(CancellationToken cancellationToken, int userId);

        Task Create(CreateBoatDto createBoatDto);

        Task<BoatDto>? AddCrewMembersToBoat(int boatId, ICollection<CreateCrewMemberDto> crewMembers, int userId);
    }

    public class BoatService : IBoatService
    {
        private readonly IBoatRepository _boatRepository;

        public BoatService(IBoatRepository boatRepository)
        {
            _boatRepository = boatRepository;
        }

        public async Task Create(CreateBoatDto createBoatDto)
        {
            await _boatRepository.Create(createBoatDto.ToBoat());
        }

        public async Task<IEnumerable<BoatDto>> GetAllAsync(CancellationToken cancellationToken, int userId)
        {
            var boats = await _boatRepository.GetAllAsync(cancellationToken, userId);

            return boats.Select(x => new BoatDto
            {
                Id = x.Id,
                BuildNumber = x.BuildNumber,
                Name = x.Name,
                Producer = x.Producer,
                LoA = x.LoA,
                B = x.B,
                ImageUrl = x.ImageUrl,
                CrewMembers = x.CrewMembers.ToDto()
            });
        }

        public async Task<BoatDto>? AddCrewMembersToBoat(int boatId, ICollection<CreateCrewMemberDto> crewMembers, int userId)
        {
            var entity = await  _boatRepository.AddCrewMembersToBoat(boatId, crewMembers, userId);

            return entity.MapToDto();
        }
    }
}
