import { Component, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule, JsonPipe } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { Router } from '@angular/router';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Usuario } from '../../model/usuario';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatFormFieldModule, MatButtonModule, MatCardModule, HttpClientModule, CommonModule, FlexLayoutModule, MatFormFieldModule, MatInputModule, ReactiveFormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent { //implements OnInit {
  email = new FormControl('', [Validators.required, Validators.email]);
  senha = new FormControl('', [Validators.required]);
  errorMessage = '';
  usuario!: Usuario;
  
  constructor(private usuarioService: UsuarioService, private  router: Router){

  }

  public logar() {
    if(this.email.invalid || this.senha.invalid){
      return
    }

    let strEmail = this.email.getRawValue() as string
    let strSenha = this.senha.getRawValue() as string

    this.usuarioService.executarLogin(strEmail, strSenha).subscribe({
      next: (response) => {
        this.usuario = response;
        sessionStorage.setItem("user", JSON.stringify(this.usuario))
        this.router.navigate(["/lista-banda"])
      }, error: (ex) =>{
        if (ex.error){
          this.errorMessage = ex.error.erro
        }
      }
    })

  }

  // constructor(private bandaService: BandaService, private router: Router){

  // }
  //ngOnInit(): void {
    // this.bandaService.getBanda().subscribe(response => {
    //   console.log(response)
    //   this.bandas = response as any
    // })
  //}

  // public goToDetail(item:Banda){
  //   this.router.navigate(["detail", item.id]);
  // }

}

export class FormFieldPrefixSuffixExample {
  hide = true;
}
