using FacebookCloneAPI.Models;
using FacebookCloneAPI.Processors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace FacebookCloneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsersController : ControllerBase
    {
        private readonly IUserProcessor processor;

        public UsersController(IUserProcessor processor)
        {
            this.processor = processor;
        }

        // GET api/Users/ping
        [HttpGet("ping")]
        public async Task<ActionResult<bool>> Ping()
        {
            return await Task.FromResult(true);
        }

        // POST api/Users/postUsers
        [HttpPost("postUser")]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            await this.processor.InsertAsync(user);
            return await Task.FromResult(Ok());
        }


        // GET api/Users/getUsers
        [HttpGet("getUser")]
        public async Task<ActionResult<User>> Get([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return await Task.FromResult(NoContent());
            }
            var result = await this.processor.FindAsync(user);
            if (result is null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(User));
        }
    }
}
