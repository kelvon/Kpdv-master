using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Receber
    {
        [PrimaryKey]
        public int Codigo { get; set; }
        public int? CodCliente { get; set; }
        public int? Nota_fiscal { get; set; }
        [MaxLength(3)]
        public string Serie { get; set; }
        public short? Emp_rec { get; set; }
        public DateTime? Dt_emissao { get; set; }
        public DateTime? Dt_entrada { get; set; }
        public DateTime? Dt_vencimento { get; set; }
        public double? Valor { get; set; }
        public double? Valor_contabilizado { get; set; }
        [MaxLength(3)]
        public string Tipo_mov { get; set; }
        public int? Cod_n_fiscal { get; set; }
        [MaxLength(1)]
        public string Origem_nf { get; set; }
        [MaxLength(2)]
        public string Situacao { get; set; }

        public virtual Cliente Cliente { get; set; }
       // public virtual ICollection<receber_custo> receber_custo { get; set; }
       // public virtual tipo_mov tipo_mov1 { get; set; }
        public virtual ICollection<Duplicata_Receber> Duplicata_Receber { get; set; }

    }
}
