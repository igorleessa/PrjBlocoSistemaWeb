using PrjBlocoSistemaWeb.Application.Conta.Dto;
using PrjBlocoSistemaWeb.Domain.Conta.Agreggates;
using PrjBlocoSistemaWeb.Domain.Streaming.Agreggates;
using System.ComponentModel.DataAnnotations;

namespace PrjBlocoSistemaWeb.Application.Streaming.Dto
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public Boolean Publica { get; set; }
        [Required]
        public virtual UsuarioDto Usuario { get; set; }
        public virtual IList<MusicaDto> Musicas { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
