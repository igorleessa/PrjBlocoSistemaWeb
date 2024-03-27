namespace PrjBlocoSistemaWeb.Domain.Streaming.Agreggates
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual IList<Musica> Musica { get; set; } = new List<Musica>();


        public void AdicionarMusica(Musica musica) =>
            this.Musica.Add(musica);

        //public void AdicionarMusica(List<Musica> musica) =>
        //    this.Musica.AddRange(musica);

    }
}
