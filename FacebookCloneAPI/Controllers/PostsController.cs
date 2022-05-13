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

        // GET api/Posts/5
        [HttpGet("{id}")]
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
        [HttpGet("all")]
        public async Task<ActionResult<List<PostInfo>>> GetAll()
        {
            return await this.processor.FindAll();
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

        // DELETE api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid postId)
        {
            await this .processor.Delete(postId);
            return await Task.FromResult(Ok());
        }
    }
}
