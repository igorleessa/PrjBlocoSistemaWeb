using PrjBlocoSistemaWeb.Domain.Core.ValueObject;
using PrjBlocoSistemaWeb.Domain.Transacao.ValueObject;

namespace PrjBlocoSistemaWeb.Domain.Transacao.Agreggates
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public DateTime DtTransacao { get; set; }
        public Monetario Valor { get; set; }
        public String Descricao { get; set; }
        public Merchant Merchant { get; set; }

    }
}
