import { Musica } from "./album"
import { Usuario } from "./usuario"

export interface Playlist {
    id?: string
    nome: string
    publica: string
    usuario: Usuario
    dtcriacao: string
    musicas?: Musica[]
}