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
        public static User ToUser(this UserDto source)
        {
            return new User
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                Username = source.Username
            };
        }
    }
}
