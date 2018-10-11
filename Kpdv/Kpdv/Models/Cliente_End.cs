using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Cliente_End
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public short? Tipo { get; set; }
        [MaxLength(64)]
        public string Endereco { get; set; }
        public int? Numero { get; set; }
        [MaxLength(200)]
        public string Complemento { get; set; }
        [MaxLength(35)]
        public string Bairro { get; set; }
        [MaxLength(35)]
        public string Cidade { get; set; }
        [MaxLength(2)]
        public string Uf { get; set; }
        [MaxLength(8)]
        public string Cep { get; set; }
        [MaxLength(60)]
        public string Pais { get; set; }
        public int Sequencia { get; set; }

        public virtual Cliente Clientes { get; set; }

    }
}
