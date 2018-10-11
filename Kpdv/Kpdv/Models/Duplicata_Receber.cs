using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Duplicata_Receber

    {
        [PrimaryKey]
        public int Codigo { get; set; }
        public int? CodCliente { get; set; }
        public int? Duplicata { get; set; }
        [MaxLength(14)]
        public string Desmembramento { get; set; }
        public DateTime? Dt_emissao { get; set; }
        public short? Num_parcelas { get; set; }
        public short? Parcelas_pagas { get; set; }
        public double? Valor { get; set; }
        [MaxLength(2)]
        public string Situacao { get; set; }

        public virtual Cliente Cliente { get; set; }
        //public virtual ICollection<duplicata_rec_desc> duplicata_rec_desc { get; set; }
        //public virtual ICollection<duplicata_rec_venc> duplicata_rec_venc { get; set; }
        public virtual ICollection<Receber> Receber { get; set; }

    }
}
