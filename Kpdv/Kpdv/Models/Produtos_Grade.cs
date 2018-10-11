using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public class Produtos_Grade
    {
        [PrimaryKey]
        [MaxLength(8)]
        public string Codigo { get; set; }
        [MaxLength(8)]
        public string Equivalente { get; set; }
        [MaxLength(8)]
        public string Cor { get; set; }
        [MaxLength(8)]
        public string Tamanho { get; set; }

        public virtual Cores Cores { get; set; }
        public virtual Produtos Produtos { get; set; }
       
    }

}
