import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MusicaService } from '../../services/musica.service';
import { MatExpansionModule } from '@angular/material/expansion';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatDividerModule} from '@angular/material/divider';
import {MatListModule} from '@angular/material/list';
import { stringToKeyValue } from '@angular/flex-layout/extended/style/style-transforms';
import { Playlist } from '../../model/Playlist';

@Component({
  selector: 'app-favoritar',
  standalone: true,
  imports: [MatExpansionModule, CommonModule, MatCardModule, MatInputModule, MatFormFieldModule, ReactiveFormsModule, MatButtonModule, MatDividerModule, MatListModule],
  templateUrl: './favoritar.component.html',
  styleUrl: './favoritar.component.css'
})
export class FavoritarComponent {
  
  playlist!: Playlist
  musicas = null
  nomeMusica = new FormControl('',[Validators.required]);

  constructor(private musicaService: MusicaService, private router: Router){

  }

  ngOnInit(): void {
    this.obterPlaylist();
  }

  public buscarMusica(){
    let strNomeMuisca = this.nomeMusica.getRawValue() as string
    this.musicaService.findMusica(strNomeMuisca).subscribe(response => {
      console.log(response)
      this.musicas = response as any
    })
   }

   public favoritarMusica(idMusica: string){
      this.musicaService.favoritarMusica(idMusica).subscribe(response =>{
        console.log(response)
        this.obterPlaylist()
      })
   }

   public obterPlaylist(){
    this.musicaService.obterPlaylist().subscribe(response =>
      {
        console.log(response)
        this.playlist = response as any
      })
   }
}
