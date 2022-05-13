using FacebookProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacebookProject.Processors
{
    public interface IPostsProcessor
    {
       Task Insert(Dictionary<string, List<string>> postInfos);

       Task<PostInfo> Find(Guid id);

       Task<List<PostInfo>> FindAll();

       Task Delete(Guid id);
    }
}
