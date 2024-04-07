import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { DetailBandaComponent } from './pages/detail-banda/detail-banda.component';
import { ListaBandaComponent } from './pages/lista-banda/lista-banda.component';
import { CadastroUsuarioComponent } from './pages/cadastro-usuario/cadastro-usuario.component';
import { FavoritarComponent } from './pages/favoritar/favoritar.component';
import { PlaylistsComponent } from './pages/playlists/playlists.component';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'detail/:id',
        component: DetailBandaComponent
    },
    {
        path: 'lista-banda',
        component: ListaBandaComponent
    },
    {
        path: 'cadastro-usuario',
        component: CadastroUsuarioComponent
    },
    {
        path: 'favoritar',
        component: FavoritarComponent
    },
    {
        path: 'playlists',
        component: PlaylistsComponent
    }
];
