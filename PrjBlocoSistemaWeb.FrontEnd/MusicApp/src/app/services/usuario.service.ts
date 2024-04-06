import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario, UsuarioCadastro } from '../model/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private url = "https://localhost:7223/api/User"
  constructor(private http: HttpClient) { }
    
  public executarLogin(email: string, senha: string) : Observable<Usuario>{
    return this.http.post<Usuario>(`${this.url}/login`, {
      email: email, senha: senha
    })
  }

  public cadastrar(nome: string, email: string, senha: string, dtNascimento: string, planoId: string, limiteCartao: string, numeroCartao: string) : Observable<Usuario>{
    
    return this.http.post<UsuarioCadastro>(`${this.url}`, {
      nome: nome, 
      email: email, 
      senha: senha,
      dtNascimento: new Date(dtNascimento),
      planoId: planoId,
      cartao: {
        ativo: true,
        limite: Number(limiteCartao),
        numero: numeroCartao
      }
    })
  }

  }
