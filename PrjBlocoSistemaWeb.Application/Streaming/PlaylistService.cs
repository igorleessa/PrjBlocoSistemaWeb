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
            var playlist = this.PlaylistRepository.GetById(id);

            var resp = new PlaylistDto();
            if (playlist != null)
            {
                resp.Id = playlist.Id;
                resp.Nome = playlist.Nome;
                resp.Publica = playlist.Publica;
                resp.DtCriacao = playlist.DtCriacao;
                resp.Usuario = new Conta.Dto.UsuarioDto();
                resp.Usuario.Id = playlist.Usuario.Id;
                resp.Usuario.Nome = playlist.Usuario.Nome;
                resp.Usuario.Email = playlist.Usuario.Email;
                resp.Usuario.Senha = playlist.Usuario.Senha;
                resp.Usuario.DtNascimento = playlist.Usuario.DtNascimento;
                resp.Musicas = new List<MusicaDto>();
                foreach (var item1 in playlist.Musicas)
                {
                    var musica = new MusicaDto();
                    musica.Id = item1.Id;
                    musica.Nome = item1.Nome;
                    musica.Duracao = item1.Duracao;
                    musica.Playlists = new List<Playlist>();
                    resp.Musicas.Add(musica);
                }
            }
            return resp;
        }


        public List<PlaylistDto> ObterPlaylistPorUsuario(Guid id)
        {
            var playlist = this.PlaylistRepository.Find(x => x.Usuario.Id == id).ToList();

            var resp = new List<PlaylistDto>();
            if (playlist != null)
            {
                foreach (var item in playlist)
                {
                    var obj = new PlaylistDto();
                    obj.Id = item.Id;
                    obj.Nome = item.Nome;
                    obj.Publica = item.Publica;
                    obj.DtCriacao = item.DtCriacao;
                    obj.Usuario = new Conta.Dto.UsuarioDto();
                    obj.Usuario.Id = item.Usuario.Id;
                    obj.Usuario.Nome = item.Usuario.Nome;
                    obj.Usuario.Email = item.Usuario.Email;
                    obj.Usuario.Senha = item.Usuario.Senha;
                    obj.Usuario.DtNascimento = item.Usuario.DtNascimento;
                    var musica = new MusicaDto();
                    foreach (var item1 in item.Musicas)
                    {
                        obj.Musicas = new List<MusicaDto>();
                        musica.Id = item1.Id;
                        musica.Nome = item1.Nome;
                        musica.Duracao = item1.Duracao;
                        musica.Playlists = new List<Playlist>();
                        obj.Musicas.Add(musica);
                    }

                    resp.Add(obj);
                }
            }
            return resp;
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

        public void AssociarFavorito(Guid idMusica, Guid idPlaylist)
        {
            var playlistFavorita = PlaylistRepository.GetById(idPlaylist);
            var musica = MusicaRepository.GetById(idMusica);

            if (playlistFavorita is null)
            {
                playlistFavorita.Musicas = new List<Musica>();
            }

            playlistFavorita.Musicas.Add(musica);

            PlaylistRepository.Update(playlistFavorita);

        }

    }
}
