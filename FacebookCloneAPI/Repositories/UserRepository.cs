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

        public async Task<User> Find(User user)
        {
            var cursor = await db.FindAsync(i => i.Username == user.Username && i.Password == user.Password).ConfigureAwait(false);
            var result = cursor.FirstOrDefault();
            if(result == null)
            {
                return null;
            }

            return await Task.FromResult(result);
        }

        public async Task Insert(User user)
        {
            var cursor = await db.FindAsync(i => i.Username == user.Username && i.Password == user.Password).ConfigureAwait(false);
            var result = cursor.FirstOrDefault();
            if (result == null)
            {
                var newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Password = user.Password
                };

                await db.InsertOneAsync(newUser);
            }
        }
    }
}
