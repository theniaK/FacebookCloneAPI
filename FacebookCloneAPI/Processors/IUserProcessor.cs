using FacebookCloneAPI.Models;
using System.Threading.Tasks;

namespace FacebookCloneAPI.Processors
{
    public interface IUserProcessor
    {
        /// <summary>
        /// Find a user in the db.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> FindAsync(User user);

        /// <summary>
        /// Insert a user in the db.
        /// </summary>
        /// <param name="user"></param>
        Task<bool> InsertAsync(User user);

        /// <summary>
        /// Delete users in the db.
        /// </summary>
        /// <param name="user"></param>
        Task DeleteAsync();
    }
}
