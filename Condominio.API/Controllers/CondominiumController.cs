using System.Threading.Tasks;
using Condominio.Application.Interfaces.Services;
using Condominio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Condominio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CondominiumController : ControllerBase
    {
        private readonly ILogger<CondominiumController> logger;
        private readonly ICondominiumService condominiumService;

        public CondominiumController(ILogger<CondominiumController> logger, ICondominiumService condominiumService)
        {
            this.logger = logger;
            this.condominiumService = condominiumService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCondominiums()
        {
            var response = await this.condominiumService.GetCondominiums();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCondominium([FromBody] Condominium request)
        {
            await this.condominiumService.CreateCondominium(request);
            return Ok(request);
        }
    }
}