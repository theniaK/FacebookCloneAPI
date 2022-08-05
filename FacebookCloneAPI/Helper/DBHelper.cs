using FacebookCloneAPI.Models;
using MongoDB.Driver;

namespace FacebookCloneAPI.Helper
{
    public static class DBHelper
    {
        public static IMongoCollection<User> GetUserDB(IMongoClient client)
        {
            var database = client.GetDatabase("Facebook");
            return database.GetCollection<User>("Users");
        }
    }
}
