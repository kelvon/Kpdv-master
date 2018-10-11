using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Cliente_Tel
    { 
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Codigo { get; set; }
        [MaxLength(3)]
        public string Ddd { get; set; }
        [MaxLength(10)]
        public string Tel { get; set; }
        [MaxLength(200)]
        public string Descricao { get; set; }
        public int Sequencia { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}
