using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Segmentos
    {
        [PrimaryKey]
        public string Codigo { get; set; }
        [MaxLength(30)]
        public string Descricao { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }

    }
}
