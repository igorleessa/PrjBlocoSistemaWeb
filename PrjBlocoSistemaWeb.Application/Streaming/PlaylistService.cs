using AutoMapper;
using PrjBlocoSistemaWeb.Application.Streaming.Dto;
using PrjBlocoSistemaWeb.Domain.Conta.Agreggates;
using PrjBlocoSistemaWeb.Domain.Streaming.Agreggates;
using PrjBlocoSistemaWeb.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjBlocoSistemaWeb.Application.Streaming
{
    public class PlaylistService
    {
        private PlaylistRepository PlaylistRepository { get; set; }
        public MusicaRepository MusicaRepository { get; set; }
        private IMapper Mapper { get; set; }


        public PlaylistService(PlaylistRepository playlistRepository, MusicaRepository musicaRepository, IMapper mapper)
        {
            PlaylistRepository = playlistRepository;
            MusicaRepository = musicaRepository;
            Mapper = mapper;
        }

        public PlaylistDto Criar(PlaylistDto dto)
        {
            Playlist playlist = this.Mapper.Map<Playlist>(dto);
            this.PlaylistRepository.Save(playlist);

            return this.Mapper.Map<PlaylistDto>(playlist);
        }

        public PlaylistDto GetById(Guid id)
        {
            var banda = this.PlaylistRepository.GetById(id);
            return this.Mapper.Map<PlaylistDto>(banda);
        }

        public List<Playlist> ObterPlaylistPorUsuario(Guid id)
        {
            return this.PlaylistRepository.Find(x => x.Usuario.Id == id).ToList();
        }

        public IEnumerable<PlaylistDto> Obter()
        {
            var banda = this.PlaylistRepository.GetAll();
            return this.Mapper.Map<IEnumerable<PlaylistDto>>(banda);
        }

        public List<Playlist> BuscarPlaylist(string nomePLaylist)
        {
            return PlaylistRepository.Find(x => x.Nome.Contains(nomePLaylist)).ToList(); 
        }

        public Playlist AssociarFavorito(Guid idMusica, Guid idPlaylist)
        {
            var playlistFavorita = PlaylistRepository.GetById(idPlaylist);
            var musica = MusicaRepository.GetById(idMusica);
            
            if(playlistFavorita is null) {
                playlistFavorita.Musicas = new List<Musica>();
            }

            playlistFavorita.Musicas.Add(musica);

            PlaylistRepository.Update(playlistFavorita);

            return playlistFavorita;
        }

    }
}
