import { Component, OnInit } from '@angular/core';
import { BandaService } from '../../services/banda.service';
import { Router } from '@angular/router';
import { Banda } from '../../model/banda';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-lista-banda',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, HttpClientModule, CommonModule, FlexLayoutModule],
  templateUrl: './lista-banda.component.html',
  styleUrl: './lista-banda.component.css'
})
export class ListaBandaComponent implements OnInit{

  bandas = null

 constructor(private bandaService: BandaService, private router: Router){

   }
  ngOnInit(): void {
     this.bandaService.getBanda().subscribe(response => {
       console.log(response)
       this.bandas = response as any
     })
  }

   public goToDetail(item:Banda){
     this.router.navigate(["detail", item.id]);
   }

}
