using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Havbruksloggen.CodingChallenge.Core.Dtos;
using Havbruksloggen.CodingChallenge.Core.Models;

namespace Havbruksloggen.CodingChallenge.Api.Converters
{
    public static class ModelConverters
    {
        public static User ToUser(this UserDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username
            };
        }
    }
}
