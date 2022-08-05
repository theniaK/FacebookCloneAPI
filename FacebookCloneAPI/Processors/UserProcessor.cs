using FacebookCloneAPI.Models;
using System.Threading.Tasks;

namespace FacebookCloneAPI.Processors
{
    public class UserProcessor : IUserProcessor
    {
        public Task<User> Find(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
