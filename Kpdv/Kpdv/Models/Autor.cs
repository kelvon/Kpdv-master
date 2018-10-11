using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public class Autor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Cod_autor { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(255)]
        public string Obs { get; set; }

        public virtual ICollection<Produtos> Produtos { get; set; }

    }
}
