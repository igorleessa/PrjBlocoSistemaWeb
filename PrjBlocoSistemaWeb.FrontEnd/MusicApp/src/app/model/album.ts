export interface Album {
    id?: string
    nome: string
    musicas?: Musica[]
}

export interface Musica {
    id?:string
    nome?:string
    duracao?:string
}
export interface Duracao {
    valor?: string
}