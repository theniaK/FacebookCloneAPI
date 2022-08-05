using FacebookCloneAPI.Models;
using FacebookCloneAPI.Repositories;
using System.Threading.Tasks;

namespace FacebookCloneAPI.Processors
{
    public class UserProcessor : IUserProcessor
    {
        private readonly IUserRepository repo;

        public UserProcessor(IUserRepository repo)
        {
            this.repo = repo;
        }

        public async Task<User> Find(User user)
        {
            var result = await this.repo.Find(user);
            return result;
        }

        public async Task Insert(User user)
        {
            await this.repo.Insert(user);
        }
    }
}
