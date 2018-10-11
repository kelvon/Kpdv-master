using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Area_Atuacao
    {
        [PrimaryKey]
        public int Codigo { get; set; }
        [MaxLength(50)]
        public string Descricao { get; set; }
        public Nullable<int> Centro_Custo { get; set; }

       // public virtual ICollection<Usuarios_Area_Atuacao> Usuarios_Area_Atuacao { get; set; }
        //public virtual ICollection<os> os { get; set; }
       // public virtual ICollection<Pedido_Venda> Pedido_Venda { get; set; }

    }
}
