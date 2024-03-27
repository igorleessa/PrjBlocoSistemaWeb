using PrjBlocoSistemaWeb.Domain.Core.ValueObject;

namespace PrjBlocoSistemaWeb.Domain.Streaming.Agreggates
{
    public class Plano
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Monetario Valor { get; set; }
    }
}
