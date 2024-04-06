import { Component } from '@angular/core';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsuarioCadastro } from '../../model/usuario';
import { UsuarioService } from '../../services/usuario.service';
import { Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-cadastro-usuario',
  standalone: true,
  imports: [MatFormFieldModule, MatButtonModule, MatCardModule, HttpClientModule, CommonModule, FlexLayoutModule, MatFormFieldModule, MatInputModule, ReactiveFormsModule],
  templateUrl: './cadastro-usuario.component.html',
  styleUrl: './cadastro-usuario.component.css'
})
export class CadastroUsuarioComponent {
  nome = new FormControl('',[Validators.required]);
  email = new FormControl('',[Validators.required, Validators.email]);
  senha = new FormControl('',[Validators.required]);
  dtNascimento = new FormControl('',[Validators.required]);
  planoId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
  limiteCartao = new FormControl('',[Validators.required]);
  numeroCartao = new FormControl('',[Validators.required]);
  erroMessage = ''
  usuario!: UsuarioCadastro

constructor(private usuarioService: UsuarioService, private router: Router){
  
}

public cadastrar(){
  if (this.nome.invalid || this.email.invalid || this.senha.invalid || this.dtNascimento.invalid || this.limiteCartao.invalid || this.numeroCartao.invalid) {
    return;
  }
  
  let strNome = this.nome.getRawValue() as string
  let strEmail = this.email.getRawValue() as string
  let strSenha = this.senha.getRawValue() as string
  let strDtNascimento = this.dtNascimento.getRawValue() as string
  let strLimiteCartao = this.limiteCartao.getRawValue() as string
  let strNumeroCartao = this.numeroCartao.getRawValue() as string

  this.usuarioService.cadastrar(strNome,strEmail,strSenha,strDtNascimento,this.planoId,strLimiteCartao,strNumeroCartao).subscribe(
    {
      next: (response) =>{
        this.usuario = response
        sessionStorage.setItem("user", JSON.stringify(this.usuario));
        this.router.navigate(["../"]);
      },
      error: (e) => {
        if(e.error){
          this.erroMessage = e.error.error
        }
      }
    })

}



}
