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
        public virtual Usuario Usuario { get; set; }
        public virtual IList<Musica> Musicas { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
