using PrjBlocoSistemaWeb.Domain.Conta.Agreggates;

namespace PrjBlocoSistemaWeb.Repository.Repository
{
    public class PlaylistRepository : RepositoryBase<Playlist>
    {
        public PrjBlocoSistemaWebContext Context { get; set; }

        public PlaylistRepository(PrjBlocoSistemaWebContext context) : base(context)
        {
            Context = context;
        }
    }
}
