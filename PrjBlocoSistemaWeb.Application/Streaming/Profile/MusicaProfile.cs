using PrjBlocoSistemaWeb.Application.Streaming.Dto;
using PrjBlocoSistemaWeb.Domain.Streaming.Agreggates;

namespace PrjBlocoSistemaWeb.Application.Streaming.Profile
{
    public class MusicaProfile : AutoMapper.Profile
    {
        public MusicaProfile()
        {
            CreateMap<MusicaDto, Musica>()
                .ReverseMap();
        }
    }
}
