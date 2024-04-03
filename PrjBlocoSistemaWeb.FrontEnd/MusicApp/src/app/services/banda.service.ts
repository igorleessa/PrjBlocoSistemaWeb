import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Banda } from '../model/banda';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { Album, Musica } from '../model/album';

@Injectable({
  providedIn: 'root'
})
export class BandaService {

  private url = "https://localhost:7223/api/Banda";
  constructor(private httpClient : HttpClient) { }

  public getBanda() : Observable<Banda[]> {
    return this.httpClient.get<Banda[]>(this.url)
  }

  public getBandaPorId(id: string) : Observable<Banda>{
    return this.httpClient.get<Banda>(`${this.url}/${id}`);
  }

  public getAlbunsBanda(id: string) : Observable<Album[]>{
    return this.httpClient.get<Album[]>(`${this.url}/${id}/albums`);
  }

  public getMusica(musica : string) : Observable<Musica>{
    return this.httpClient.get<Musica>(`${this.url}/musica/${musica}`)
  }
}
