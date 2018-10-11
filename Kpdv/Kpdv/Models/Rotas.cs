using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Rotas
    {
        [PrimaryKey]
        public int Codigo { get; set; }
        [MaxLength(30)]
        public string Descricao { get; set; }
        public Nullable<short> Prioridade { get; set; }
        public int Codigo_regiao { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }

    }

}
