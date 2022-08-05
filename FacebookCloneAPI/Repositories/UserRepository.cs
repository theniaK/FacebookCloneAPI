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
            var builder = Builders<User>.Filter;
            var filter = builder.Gt("Username", user.Username) & builder.Gt("Password", user.Password);
            var cursor = await db.FindAsync(filter);
            var result = cursor.FirstOrDefault();
            if (result == null)
            {
                return null;
            }

            return await Task.FromResult(result);
        }

        public async Task InsertAsync(User user)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Gt("Username", user.Username) & builder.Gt("Password", user.Password);
            var cursor = await db.FindAsync(filter);
            var result = cursor.FirstOrDefault();
            //var result = db.Find(s => s.FirstName == user.FirstName).FirstOrDefault();

            if (result == null)
            {
                var newUser = new User
                {
                    Id = System.Guid.NewGuid(),
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
