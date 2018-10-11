using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public class Cores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(3)]
        public string Codigo { get; set; }
        [MaxLength(30)]
        public string Descricao { get; set; }
        [MaxLength(10)]
        public string Cor_fabrica { get; set; }

       public virtual ICollection<Produtos_Grade> Produtos_Grade { get; set; }

    }
}
