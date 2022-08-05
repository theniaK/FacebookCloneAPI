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
        Task<User> Find(string username, string password);

        /// <summary>
        /// Insert a user in the db.
        /// </summary>
        /// <param name="user"></param>
        Task Insert(User user);
    }
}
