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

        public async Task<User> FindAsync(User user)
        {
            var result = await this.repo.FindAsync(user);
            return result;
        }

        public async Task InsertAsync(User user)
        {
            await this.repo.InsertAsync(user);
        }
    }
}
