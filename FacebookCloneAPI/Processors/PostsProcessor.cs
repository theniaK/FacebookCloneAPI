using FacebookCloneApi.Models;
using FacebookCloneApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacebookCloneApi.Processors
{
    public class PostsProcessor :IPostsProcessor
    {
        private readonly IPostsRepository repo;

        public PostsProcessor(IPostsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Insert(Dictionary<string, List<string>> postInfos)
        {
            await this.repo.Insert(postInfos);
        }

        public async Task Insert(PostInfo postInfo)
        {
            await this.repo.Insert(postInfo);
        }

        public async Task<PostInfo> Find(Guid id)
        {
            return await this.repo.Find(id);
        }

        public async Task<List<PostInfo>> FindAll()
        {
            return await this.repo.FindAll();
        }

        public async Task Delete(Guid id)
        {
            await this.repo.Delete(id);
        }

        public async Task Delete()
        {
            await this.repo.Delete();
        }
    }
}
