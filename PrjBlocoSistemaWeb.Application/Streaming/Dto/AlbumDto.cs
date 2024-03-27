using System.ComponentModel.DataAnnotations;

namespace PrjBlocoSistemaWeb.Application.Streaming.Dto
{
    public class AlbumDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid BandaId { get; set; }

        [Required]
        public string Nome { get; set; }
        public List<MusicDto> Musicas { get; set; } = new List<MusicDto>();

    }


    public class MusicDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public int Duracao { get; set; }

    }
}
