using Microsoft.AspNetCore.Mvc;
using PrjBlocoSistemaWeb.Application.Streaming;
using PrjBlocoSistemaWeb.Application.Streaming.Dto;

namespace PrjBlocoSistemaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private MusicaService _musicaService;

        public MusicaController(MusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        [HttpGet]
        public IActionResult GetMusicas()
        {
            var result = this._musicaService.Obter();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMusicas(Guid id)
        {
            var result = this._musicaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] MusicaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._musicaService.Criar(dto);

            return Ok(result);
            //return Created($"/musica/{result.Id}", result);
        }

        [HttpPost("{nomeMusica}")]
        public IActionResult BuscarMusica(string nomeMusica)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._musicaService.BuscarMusica(nomeMusica);

            return Created($"/musica/{result.Id}", result);

        }
    }
}
