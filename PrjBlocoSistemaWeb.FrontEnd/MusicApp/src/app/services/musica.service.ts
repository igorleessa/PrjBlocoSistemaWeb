import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Musica } from '../model/album';

@Injectable({
  providedIn: 'root'
})
export class MusicaService {
  private url = "https://localhost:7223/api/Musica";

  constructor(private httpClient : HttpClient) { }

  public findMusica(nomeMusica :string) : Observable<Musica[]> {
    return this.httpClient.get<Musica[]>(`${this.url}/BuscarMusica?${nomeMusica}`);
  }
}
