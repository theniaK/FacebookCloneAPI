using FacebookCloneApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacebookCloneApi.Processors
{
    public interface IPostsProcessor
    {
       Task Insert(Dictionary<string, List<string>> postInfos);

       Task Insert(PostInfo postInfo);

       Task<PostInfo> Find(Guid id);

       Task<List<PostInfo>> FindAll();

       Task Delete(Guid id);

       Task Delete();
    }
}
