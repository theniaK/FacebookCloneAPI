using FacebookProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacebookProject.Repositories
{
    public interface IPostsRepository
    {
        Task Insert(Dictionary<string, List<string>> postInfos);

        Task<PostInfo> Find(Guid id);

        Task<List<PostInfo>> FindAll();

        Task Delete(Guid id);
    }
}
