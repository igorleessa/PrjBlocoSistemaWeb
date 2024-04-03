using PrjBlocoSistemaWeb.Domain.Streaming.Agreggates;

namespace PrjBlocoSistemaWeb.Repository.Repository
{
    public class MusicaRepository : RepositoryBase<Musica>
    {
        public PrjBlocoSistemaWebContext Context { get; set; }

        public MusicaRepository(PrjBlocoSistemaWebContext context) : base(context)
        {
            Context = context;
        }
    }
}
