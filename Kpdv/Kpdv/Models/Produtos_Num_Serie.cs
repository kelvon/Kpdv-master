using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public class Produtos_Num_Serie
    {
        [PrimaryKey]
        public int Codigo { get; set; }
        [MaxLength(8)]
        public string Codigo_int { get; set; }
        [MaxLength(30)]
        public string Num_serie { get; set; }
        public bool? Disponivel { get; set; }

       public virtual Produtos Produtos { get; set; }

    }
}
