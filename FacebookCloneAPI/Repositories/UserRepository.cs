using FacebookCloneAPI.Helper;
using FacebookCloneAPI.Models;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace FacebookCloneAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> db;

        public UserRepository(IMongoClient client)
        {
            this.db = DBHelper.GetUserDB(client);
        }

        public async Task DeleteAsync()
        {
            await this.db.DeleteManyAsync(Builders<User>.Filter.Empty);
        }

        public async Task<User> FindAsync(User user)
        {
            var result = await GetUser(user);
            if (result == null)
            {
                return null;
            }

            return await Task.FromResult(result);
        }

        public async Task<bool> InsertAsync(User user)
        {
            var result = await GetUser(user);
            if (result != null)
            {
                return false;
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password
            };

            await db.InsertOneAsync(newUser);
            return true;
        }

        private async Task<User> GetUser(User user)
        {
            var cursor = await db.FindAsync(s => s.Username == user.Username && s.Password == user.Password);
            var result = cursor.FirstOrDefault();
            return result;
        }
    }
}
