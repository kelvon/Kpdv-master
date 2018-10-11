using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Pedido_Venda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int? CodPedido { get; set; }
        public int? cliente { get; set; }
        public System.DateTime Data { get; set; }
        public DateTime? Validade { get; set; }
        public DateTime? Data_faturamento { get; set; }
        public int? CodVendedor { get; set; }
        [MaxLength(3)]
        public string Forma_pag { get; set; }
        public DateTime? Previsao_entrega { get; set; }
        [MaxLength(500)]
        public string Local_entrega { get; set; }
        [MaxLength(8)]
        public string Hora_entrega { get; set; }
        [MaxLength(500)]
        public string Obs { get; set; }
        public double? Total { get; set; }
        public short? Tipo { get; set; }
        public DateTime? Vencimento_pedido { get; set; }
        public bool? Imprimenf { get; set; }
        [MaxLength(500)]
        public string Obs_faturamento { get; set; }
        [MaxLength(64)]
        public string Num_ped_cliente { get; set; }
        public bool? Recibo { get; set; }
        [MaxLength(500)]
        public string Infoentrega { get; set; }
        public int? Abertopor { get; set; }
        [MaxLength(8)]
        public string Hora_aberto { get; set; }
        public int? Fechadopor { get; set; }
        public DateTime? Data_fechado { get; set; }
        [MaxLength(8)]
        public string Hora_fechado { get; set; }
        public bool? Despacho { get; set; }
        public int? Coo_vinculado { get; set; }
        public int? Coo { get; set; }
        public int? Ccf { get; set; }
        public short? Numero_ecf { get; set; }
        [MaxLength(1)]
        public string Situacao { get; set; }
        public int? area_atuacao { get; set; }
        [MaxLength(60)]
        public string NOME_CLIENTE { get; set; }
        [MaxLength(60)]
        public string TELEFONE_CLIENTE { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Forma_Pagamento Forma_Pagamento { get; set; }
        public virtual Area_Atuacao Area_atuacao { get; set; }
        public virtual ICollection<Pedido_Venda_Prod> Pedido_Venda_Prod { get; set; }

        public static implicit operator ObservableCollection<object>(Pedido_Venda v)
        {
            throw new NotImplementedException();
        }
    }
}
