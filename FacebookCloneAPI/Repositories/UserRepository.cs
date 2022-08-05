using FacebookCloneAPI.Models;
using MongoDB.Driver;

namespace FacebookCloneAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> db;

        public UserRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Facebook");
            db = database.GetCollection<User>("Users");
        }
    }
}
