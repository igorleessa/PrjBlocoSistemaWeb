namespace PrjBlocoSistemaWeb.Domain.Streaming.Agreggates
{
    public class Banda
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public String Backdrop { get; set; }
        public virtual IList<Album> Albums { get; set; } = new List<Album>();

        public void AdicionarAlbum(Album album) =>
            this.Albums.Add(album);
    }
}
