using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Cliente_Contato
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Codigo { get; set; }
        [MaxLength(250)]
        public string Contato { get; set; }
        [MaxLength(20)]
        public string Setor { get; set; }
        [MaxLength(20)]
        public string Cargo { get; set; }
        public short? Ddd { get; set; }
        [MaxLength(9)]
        public string Telefone { get; set; }
        public short? Ddd_fax { get; set; }
        [MaxLength(9)]
        public string Fax { get; set; }
        public string Ddd_celular { get; set; }
        [MaxLength(9)]
        public string Celular { get; set; }
        [MaxLength(1)]
        public string Sexo { get; set; }
        public DateTime? Aniversario { get; set; }
        [MaxLength(200)]
        public string E_mail { get; set; }
        [MaxLength(500)]
        public string Obs { get; set; }
        [MaxLength(1)]
        public string Situacao { get; set; }
        public int Sequencia { get; set; }

        public virtual Cliente Clientes { get; set; }

    }
}
