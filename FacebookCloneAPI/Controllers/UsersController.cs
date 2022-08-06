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

        // POST api/Users/postUsers  SignUp
        [HttpPost("postUser")]
        public async Task<ActionResult<bool>> Post([FromBody] User user)
        {
            var userExists = await this.processor.InsertAsync(user);
            if (!userExists)
            {
                return await Task.FromResult(BadRequest("The user exists!"));
            }
            return await Task.FromResult(Ok("User inserted succesfully!"));
        }


        // GET api/Users/getUsers  LogIn
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
                return await Task.FromResult(NotFound("User not found!"));
            }

            return await Task.FromResult(result);
        }

        [HttpDelete("deleteUsers")]
        public async Task<ActionResult> DeleteALl()
        {
            await this.processor.DeleteAsync();
            return await Task.FromResult(Ok("All users deleted!"));
        }
    }
}
