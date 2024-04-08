import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Musica } from '../model/album';
import { Playlist } from '../model/Playlist';
import { Usuario } from '../model/usuario';

@Injectable({
  providedIn: 'root'
})
export class MusicaService {
  private url = "https://localhost:7223/api/Musica";
  private urlPlaylist = "https://localhost:7223/api/Playlist";


  constructor(private httpClient : HttpClient) { }

  public findMusica(nomeMusica :string) : Observable<Musica[]> {
    return this.httpClient.get<Musica[]>(`${this.url}/BuscarMusica?nomeMusica=${nomeMusica}`);
  }

  public favoritarMusica(idMusica: string) : Observable<Playlist> {
    let playlistSession = sessionStorage.getItem("playlist") + "";
    let playlistJson = JSON.parse(playlistSession)
    let playlist = playlistJson as Playlist;
    return this.httpClient.post<Playlist>(`${this.urlPlaylist}/Favoritar?idMusica=${idMusica}&idPlaylist=${playlist.id}`,"")
  }

  public obterPlaylistsUsuario() :Observable<Playlist[]> {
    let usuarioSession = sessionStorage.getItem("user") + "";
    let usuarioJson = JSON.parse(usuarioSession)
    let usuario = usuarioJson as Usuario;
    console.log(usuario)
    console.log(`${this.urlPlaylist}/ObterPlaylistPorUsuario?${usuario.id}`)
    return this.httpClient.get<Playlist[]>(`${this.urlPlaylist}/ObterPlaylistPorUsuario?id=${usuario.id}`);
  }

  public obterPlaylist() :Observable<Playlist> {
    let playlistSession = sessionStorage.getItem("playlist") + "";
    let playlistJson = JSON.parse(playlistSession)
    let playlist = playlistJson as Playlist;
    return this.httpClient.get<Playlist>(`${this.urlPlaylist}/${playlist.id}`);
  }
}
