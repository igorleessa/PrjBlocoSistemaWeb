import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Route } from '@angular/router';
import { CommonModule } from '@angular/common';
import {MatExpansionModule} from '@angular/material/expansion';
import { BandaService } from '../services/banda.service';

@Component({
  selector: 'app-musica',
  standalone: true,
  imports: [MatExpansionModule, CommonModule],
  templateUrl: './musica.component.html',
  styleUrl: './musica.component.css'
})
export class MusicaComponent implements OnInit {
  idMusica = ''


  constructor(private route: ActivatedRoute, private bandaService: BandaService){

  }
  
  ngOnInit(): void {
    this.idMusica = this.route.snapshot.params["id"]
    
  }
}

