using PrjBlocoSistemaWeb.Domain.Conta.Agreggates;
using PrjBlocoSistemaWeb.Domain.Streaming.ValueObject;

namespace PrjBlocoSistemaWeb.Domain.Streaming.Agreggates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public Duracao Duracao { get; set; }

        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();

    }
}
