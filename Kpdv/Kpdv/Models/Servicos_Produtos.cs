using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public class Servicos_Produtos
    {
        [PrimaryKey]
        [MaxLength(8)]
        public string Codigo_servico { get; set; }
        [PrimaryKey]
        [MaxLength(8)]
        public string Codigo_peca { get; set; }

        public virtual Servicos Servicos { get; set; }
        public virtual Produtos Produtos { get; set; }
    }

}
