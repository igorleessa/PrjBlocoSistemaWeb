using Microsoft.AspNetCore.Mvc;
using PrjBlocoSistemaWeb.Application.Streaming;
using PrjBlocoSistemaWeb.Application.Streaming.Dto;

namespace PrjBlocoSistemaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {
        private BandaService _bandaService;

        public BandaController(BandaService bandaService)
        {
            _bandaService = bandaService;
        }

        [HttpGet]
        public IActionResult GetBandas()
        {
            var result = this._bandaService.Obter();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBandas(Guid id)
        {
            var result = this._bandaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] BandaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._bandaService.Criar(dto);

            return Created($"/banda/{result.Id}", result);
        }

        [HttpPost("{id}/albums")]
        public IActionResult AssociarAlbum(AlbumDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._bandaService.AssociarAlbum(dto);

            return Created($"/banda/{result.BandaId}/albums/{result.Id}", result);

        }


        [HttpGet("{idBanda}/albums/{id}")]
        public IActionResult ObterAlbumPorId(Guid idBanda, Guid id)
        {
            var result = this._bandaService.ObterAlbumPorId(idBanda, id);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("{idBanda}/albums")]
        public IActionResult ObterAlbuns(Guid idBanda)
        {
            var result = this._bandaService.ObterAlbum(idBanda);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

    }
}
