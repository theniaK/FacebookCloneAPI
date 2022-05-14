using FacebookCloneApi.Models;
using FacebookCloneApi.Processors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace FacebookCloneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PostsController : ControllerBase
    {
        private IPostsProcessor processor;

        public PostsController(IPostsProcessor processor)
        {
            this.processor = processor;
        }

        // GET api/Posts/ping
        [HttpGet("ping")]
        public async Task<ActionResult<bool>> Ping()
        {
            return await Task.FromResult(true);
        }

        // POST api/Posts/post
        [HttpPost("post")]
        public async Task<ActionResult> Post([FromBody] Dictionary<string, List<string>> postInfos)
        {
            if (postInfos.Count != 0)
            {
                await this.processor.Insert(postInfos);
                return await Task.FromResult(Ok());
            }

            return NoContent();
        }

        // GET api/Posts/all/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<PostInfo>> Get(Guid id)
        {
            var result = this.processor.Find(id);
            if (result is null)
            {
                return await Task.FromResult(NotFound());
            }

            return await this.processor.Find(id);
        }

        // GET api/Posts/all
        [HttpGet("get")]
        public async Task<ActionResult<List<PostInfo>>> GetAll()
        {
            return await this.processor.FindAll();
        }

        // DELETE api/Posts/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await this .processor.Delete(id);
            return await Task.FromResult(Ok());
        }

        // DELETE api/Posts/delete
        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteAll()
        {
            await this.processor.Delete();
            return await Task.FromResult(Ok());
        }
    }
}
