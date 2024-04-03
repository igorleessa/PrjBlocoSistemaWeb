using AutoMapper;
using PrjBlocoSistemaWeb.Application.Streaming.Dto;
using PrjBlocoSistemaWeb.Domain.Streaming.Agreggates;
using PrjBlocoSistemaWeb.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjBlocoSistemaWeb.Application.Streaming
{
    public class MusicaService
    {
        private MusicaRepository MusicaRepository { get; set; }
        private IMapper Mapper { get; set; }


        public MusicaService(MusicaRepository musicaRepository, IMapper mapper)
        {
            MusicaRepository = musicaRepository;
            Mapper = mapper;
        }

        public MusicaDto Criar(MusicaDto dto)
        {
            Musica musica = this.Mapper.Map<Musica>(dto);
            this.MusicaRepository.Save(musica);

            return this.Mapper.Map<MusicaDto>(musica);
        }

        public MusicaDto Obter(Guid id)
        {
            var banda = this.MusicaRepository.GetById(id);
            return this.Mapper.Map<MusicaDto>(banda);
        }

        public IEnumerable<MusicaDto> Obter()
        {
            var banda = this.MusicaRepository.GetAll();
            return this.Mapper.Map<IEnumerable<MusicaDto>>(banda);
        }

        public MusicaDto BuscarMusica(string nomeMusica)
        {
            var musica = this.MusicaRepository.Find(x => x.Nome == nomeMusica).FirstOrDefault();
            if (musica == null)
                throw new Exception("Música não encontrada");
            var result = this.Mapper.Map<MusicaDto>(musica);
            return result;

        }

        //public MusicaDto FavoritarMusica()
        //{
        //}

    }
}
