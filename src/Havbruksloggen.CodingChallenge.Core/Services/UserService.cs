using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havbruksloggen.CodingChallenge.Core.Entities;
using Havbruksloggen.CodingChallenge.Core.Repositories;

namespace Havbruksloggen.CodingChallenge.Core.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string userName, string password);

        Task<User> Create(User user, string password);

        User GetUserById(int userId);

    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            var user = await _userRepository.GetByUsername(userName);

            if (user is null)
                return null;

            return !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) ? null : user;
        }

        public async Task<User> Create(User user, string password)
        {
            return await this._userRepository.Create(user, password);
        }

        public User GetUserById(int userId)
        {
            return this._userRepository.GetById(userId);
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException(
                $"Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException(
                $"Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (computedHash.Where((t, i) => t != storedHash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
