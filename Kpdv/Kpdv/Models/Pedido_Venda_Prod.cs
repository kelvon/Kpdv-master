using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public class Pedido_Venda_Prod
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Codauto { get; set; }
        public int? Pedido { get; set; }
        [MaxLength(8)]
        public string Produto { get; set; }
        public float? Qtd_pedida { get; set; }
        public float? Troca { get; set; }
        public float? P_normal { get; set; }
        public float? Atendido_acumulado { get; set; }
        public float? Desconto { get; set; }
        public float? Acrescimo { get; set; }
        public float? Qtd_atendida { get; set; }
        public float? P_venda { get; set; }
        public float? Custo_ped { get; set; }
        public float? Ajustar { get; set; }
        public float? Qtd_faturada { get; set; }
        public float? Qtd_devolvida { get; set; }
        public float? Comprimento { get; set; }
        public float? Largura { get; set; }
        public double? Area_venda { get; set; }
        [MaxLength(500)]
        public string Descricao_produto { get; set; }
        [MaxLength(2)]
        public string Unidade_pedido { get; set; }
        [MaxLength(3)]
        public string Situacao_item { get; set; }
        public bool? Item_cancelado { get; set; }
        public DateTime? Data_inclusao_item { get; set; }
        public DateTime? Data_alteracao_item { get; set; }
        public DateTime? Data_cancelamento_item { get; set; }

        public virtual Produtos Produtos { get; set; }
        public virtual Pedido_Venda Pedido_Venda { get; set; }
        public virtual Servicos Servicos { get; set; }

    }
}
