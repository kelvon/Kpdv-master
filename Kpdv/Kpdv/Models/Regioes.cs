using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public partial class Regioes
    {
        [PrimaryKey]
        public int Codigo { get; set; }
        [MaxLength(20)]
        public string Descricao { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }

    }
}
