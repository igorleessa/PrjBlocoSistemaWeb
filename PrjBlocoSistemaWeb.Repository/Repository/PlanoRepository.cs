using PrjBlocoSistemaWeb.Domain.Streaming.Agreggates;

namespace PrjBlocoSistemaWeb.Repository.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>
    {
        public PrjBlocoSistemaWebContext Context { get; set; }

        public PlanoRepository(PrjBlocoSistemaWebContext context) : base(context)
        {
            Context = context;
        }
    }
}
