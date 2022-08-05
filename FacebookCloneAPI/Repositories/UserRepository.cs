using FacebookCloneAPI.Helper;
using FacebookCloneAPI.Models;
using MongoDB.Driver;
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

        public async Task<User> FindAsync(User user)
        {
            var cursor = await db.FindAsync(s => s.Username == user.Username);
            var result = cursor.FirstOrDefault();
            if (result == null)
            {
                return null;
            }

            return await Task.FromResult(result);
        }

        public async Task<bool> InsertAsync(User user)
        {
            var cursor = await db.FindAsync(s => s.Username == user.Username);
            var result = cursor.FirstOrDefault();
            if (result != null)
            {
                return false;
            }

            var newUser = new User
            {
                Id = System.Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password
            };

            await db.InsertOneAsync(newUser);
            return true;
        }
    }
}
