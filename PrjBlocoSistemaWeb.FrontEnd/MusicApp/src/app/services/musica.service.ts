import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Musica } from '../model/album';
import { Playlist } from '../model/Playlist';

@Injectable({
  providedIn: 'root'
})
export class MusicaService {
  private url = "https://localhost:7223/api/Musica";
  private urlPlaylist = "https://localhost:7223/api/Playlist";


  constructor(private httpClient : HttpClient) { }

  public findMusica(nomeMusica :string) : Observable<Musica[]> {
    return this.httpClient.get<Musica[]>(`${this.url}/BuscarMusica?${nomeMusica}`);
  }

  public favoritarMusica(idMusica: string, idPlaylist: string) : Observable<Playlist> {
    return this.httpClient.post<Playlist>(`${this.urlPlaylist}/Favoritar`,{
      idMusica: idMusica,
      idPlaylist: idPlaylist
    })
  }

  public obterPlaylistsUsuario() :Observable<Playlist[]> {
    let idUsuario = sessionStorage.getItem("user");
    return this.httpClient.get<Playlist[]>(`${this.urlPlaylist}/ObterPlaylistPorUsuario?${idUsuario}`);
  }

  public obterPlaylist() :Observable<Playlist> {
    let idPlaylist = sessionStorage.getItem("idPlaylist");
    return this.httpClient.get<Playlist>(`${this.urlPlaylist}/${idPlaylist}`);
  }
}
