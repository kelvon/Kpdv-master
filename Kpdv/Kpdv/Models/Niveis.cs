using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public class Niveis
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Cod_nivel { get; set; }
        [MaxLength(3)]
        public string Nivel1 { get; set; }
        [MaxLength(3)]
        public string Nivel2 { get; set; }
        [MaxLength(3)]
        public string Nivel3 { get; set; }
        [MaxLength(3)]
        public string Nivel4 { get; set; }
        [MaxLength(3)]
        public string Nivel5 { get; set; }
        [MaxLength(35)]
        public string Descr { get; set; }
        public int? Custo { get; set; }
        public int? Classe_entrada { get; set; }
        public int? Sub_classe_entrada { get; set; }
        public int? Classe_saida { get; set; }
        public int? Sub_classe_saida { get; set; }

        public virtual ICollection<Produtos> Produtos { get; set; }
        public virtual ICollection<Servicos> Servicos { get; set; }

    }

}
