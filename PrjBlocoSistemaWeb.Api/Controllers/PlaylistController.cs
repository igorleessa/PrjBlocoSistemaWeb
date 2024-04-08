using Microsoft.AspNetCore.Mvc;
using PrjBlocoSistemaWeb.Application.Streaming;
using PrjBlocoSistemaWeb.Application.Streaming.Dto;

namespace PrjBlocoSistemaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private PlaylistService _playlistService;

        public PlaylistController(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public IActionResult GetPlaylists()
        {
            var result = this._playlistService.Obter();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = this._playlistService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("ObterPlaylistPorUsuario")]
        public IActionResult ObterPlaylistPorUsuario(Guid id)
        {
            var result = this._playlistService.ObterPlaylistPorUsuario(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] PlaylistDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._playlistService.Criar(dto);

            return Ok(result);
            //return Created($"/musica/{result.Id}", result);
        }

        [HttpGet]
        [Route("BuscarPlaylist")]
        public IActionResult BuscarPlaylist(string nomePlaylist)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._playlistService.BuscarPlaylist(nomePlaylist);
            
            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpPost]
        [Route("Favoritar")]
        public IActionResult FavoritarMusica(Guid idMusica, Guid idPlaylist)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();
            
            this._playlistService.AssociarFavorito(idMusica, idPlaylist);

            return Ok();

        }
    }
}
