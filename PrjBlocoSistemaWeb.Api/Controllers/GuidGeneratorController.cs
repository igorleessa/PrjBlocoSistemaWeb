using Microsoft.AspNetCore.Mvc;
using PrjBlocoSistemaWeb.Application.Conta;
using PrjBlocoSistemaWeb.Application.Conta.Dto;

namespace PrjBlocoSistemaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidGeneratorController : ControllerBase
    {

        public GuidGeneratorController()
        {
        
        }

        [HttpGet]
        public IActionResult Get()
        {
            string guid = new string(Guid.NewGuid().ToString());

            return Ok(guid);
        }

    }
}
