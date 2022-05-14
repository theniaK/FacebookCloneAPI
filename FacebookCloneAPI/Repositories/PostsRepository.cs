using FacebookCloneApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacebookCloneApi.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private IMongoCollection<PostInfo> db;

        public PostsRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Users");
            db = database.GetCollection<PostInfo>("Posts");
        }

        public async Task Insert(Dictionary<string, List<string>> postInfos)
        {
            foreach (var info in postInfos)
            {
                var postInfo = new PostInfo
                {
                    Id = new Guid(),
                    Title = info.Key,
                    Description = info.Value[0],
                    Date = DateTime.Now,
                };

                var cursor = await db.FindAsync(s => s.Title == info.Key);
                var infos = cursor.FirstOrDefault();

                if (infos == null)
                {
                    await db.InsertOneAsync(postInfo);
                }

            }
        }

        public async Task<PostInfo> Find(Guid id)
        {
            var cursor = await db.FindAsync(s => s.Id == id);
            var postInfos = cursor.FirstOrDefault();
            return await Task.FromResult(postInfos);
        }

        public async Task<List<PostInfo>> FindAll()
        {
            var cursor = await db.FindAsync(Builders<PostInfo>.Filter.Empty);
            var postInfos = cursor.ToList();
            return await Task.FromResult(postInfos);
        }

        public async Task Delete(Guid id)
        {
            var filter = Builders<PostInfo>.Filter.Eq(s => s.Id, id);
            // This is a faster ways to traverse a db when you have million elements!
            //var filter = Builders<PostInfo>.IndexKeys.Ascending(e => e.Id == id);

            await db.DeleteOneAsync(filter);
        }

        public async Task Delete()
        {
            await db.DeleteManyAsync(Builders<PostInfo>.Filter.Empty);
        }
    }
}
