using System.Threading.Tasks;
using Condominio.Application.Interfaces.Services;
using Condominio.Application.Products.Commands.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Condominio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CondominiumController : ControllerBase
    {
        private readonly ILogger<CondominiumController> logger;

        public CondominiumController(ILogger<CondominiumController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetAllCondominiums([FromServices]ICondominiumService condominiumService)
        {
            var response = await condominiumService.GetAllCondominiums();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCondominium([FromServices]ICondominiumService condominiumService, [FromBody]CreateCondominiumRequest request)
        {
            var response = await condominiumService.CreateCondominium(request);
            return Ok(response);
        }
    }
}