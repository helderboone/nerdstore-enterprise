﻿using System.Collections.Generic;

namespace NSE.Bff.Compras.Models
{
    public class CarrinhoDTO 
    {
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public List<ItemCarrinhoDTO> Itens { get; set; } = new List<ItemCarrinhoDTO>();
    }
}
