using System.Threading.Tasks;
using Condominio.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Condominio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService user;
        private readonly ILogger<UserController> logger;

        public UserController(IUserService user, ILogger<UserController> logger)
        {
            this.user = user;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetUserById()
        {
            var response = await user.GetUserById();
            return Ok(response);
        }
    }
}