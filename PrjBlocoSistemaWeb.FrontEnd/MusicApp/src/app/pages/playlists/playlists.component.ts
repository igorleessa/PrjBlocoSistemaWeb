import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MusicaService } from '../../services/musica.service';
import { Playlist } from '../../model/Playlist';
import {MatDividerModule} from '@angular/material/divider';
import {MatListModule} from '@angular/material/list';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-playlists',
  standalone: true,
  imports: [MatListModule, MatDividerModule, CommonModule],
  templateUrl: './playlists.component.html',
  styleUrl: './playlists.component.css'
})
export class PlaylistsComponent implements OnInit {

  playlists = null

  constructor(private route: ActivatedRoute, private musicaService: MusicaService,  private router: Router){

  }
  
  ngOnInit(): void {
    this.musicaService.obterPlaylistsUsuario().subscribe(response =>
      {
        console.log(response)
        this.playlists = response as any
      })
  }

  public goPlaylist(item: Playlist){
    this.router.navigate(["Favoritar", item.id]);
  }
}
