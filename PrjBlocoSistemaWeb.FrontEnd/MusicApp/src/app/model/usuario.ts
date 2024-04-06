export interface Usuario {
    id?: String;
    nome?: String;
    email?: String;
    dtNascimento?: String;
}

export interface UsuarioCadastro {
    idPlano?: String;
    nome?: String;
    email?: String;
    senha?: String;
    dtNascimento?: String;
    cartao?: Cartao;
}

export interface Cartao {
    ativo?: String;
    limite?: String;
    Numero?: string
}