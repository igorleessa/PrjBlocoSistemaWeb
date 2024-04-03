using PrjBlocoSistemaWeb.Domain.Conta.Agreggates;
using PrjBlocoSistemaWeb.Domain.Streaming.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace PrjBlocoSistemaWeb.Application.Streaming.Dto
{
    public class MusicaDto
    {
        public Guid Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public Duracao Duracao { get; set; }

        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
