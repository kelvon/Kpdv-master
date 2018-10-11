using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Funcoes
    {
        [PrimaryKey]
        [MaxLength(3)]
        public string Codigo { get; set; }
        [MaxLength(30)]
        public string Descricao { get; set; }
        public Nullable<bool> Altera_cx { get; set; }
        public Nullable<bool> Cancelar_os { get; set; }
        public Nullable<bool> Altera_tec_resp_os { get; set; }

       

    }
}
