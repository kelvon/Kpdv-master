using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Forma_Pagamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(3)]
        public string Codigo { get; set; }
        [MaxLength(50)]
        public string Descricao { get; set; }
        [MaxLength(2)]
        public string Tipo { get; set; }
        [MaxLength(1)]
        public string Situacao { get; set; }
       
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Pedido_Venda> Pedido_Venda { get; set; }



    }
}
