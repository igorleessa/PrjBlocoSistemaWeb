﻿namespace PrjBlocoSistemaWeb.Application.Conta.Dto
{

    public class CartaoDto
    {
        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public Decimal Limite { get; set; }
        public String Numero { get; set; }

    }
}
