using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Havbruksloggen.CodingChallenge.Core.Dtos;
using Havbruksloggen.CodingChallenge.Core.Extensions;
using Havbruksloggen.CodingChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
#nullable enable

namespace Havbruksloggen.CodingChallenge.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        User? GetById(int id);

        Task<User> Create(User user, string password);

        Task Update(User userParam, string password = null);

        Task Delete(int id);

        Task<User>? GetByUsername(string userName);
    }

    public class UserRepository : RepositoryBase<User, ApplicationDbContext>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }


        public async Task<IEnumerable<User>> GetAll()
        {
            return await DbContext.Users.AsNoTracking()
                .ToListAsync();
        }

        public User? GetById(int id)
        {
            return DbContext.Users.Find(id);
        }

        public async Task<User>? GetByUsername(string userName)
        {
            return await DbContext.Users.SingleOrDefaultAsync(x => x.Username == userName);
        }

        public async Task<User> Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            var result = await DbContext.Users.AnyAsync(x => x.Username == user.Username);

            if (result)
                throw new Exception("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            return user;
        }

        public async Task Update(User userParam, string password = null)
        {
            var user = await DbContext.Users.FindAsync(userParam.Id);

            if (user == null)
                throw new Exception("User not found");

            // update Username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new Username is already taken
                if (DbContext.Users.Any(x => x.Username == userParam.Username))
                    throw new Exception("Username " + userParam.Username + " is already taken");

                user.Username = userParam.Username;
            }

            // update User properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            DbContext.Users.Update(user);
            DbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var user = await DbContext.Users.FindAsync(id);
            if (!(user is null))
            {
                DbContext.Users.Remove(user);
                DbContext.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
