import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Route, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import {MatExpansionModule} from '@angular/material/expansion';
import { MusicaService } from '../../services/musica.service';
import { Musica } from '../../model/album';

@Component({
  selector: 'app-musica',
  standalone: true,
  imports: [MatExpansionModule, CommonModule],
  templateUrl: './musica.component.html',
  styleUrl: './musica.component.css'
})

export class MusicaComponent implements OnInit {

  musicas!: Musica[]

  constructor(private route: ActivatedRoute, private router: Router, private musicaService: MusicaService){

  }
  
  ngOnInit(): void {
    // this.musicaService.findMusica().subscribe(response => {
    //   this.musicas = response as any;
    // })    
  }

  public buscarMusicas(nomeMusica: string){
    this.musicaService.findMusica("Vira").subscribe(response => {
      this.musicas = response
      console.log(response)
    })
  }
}

