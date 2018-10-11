using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public enum Situacao
    {
        A,
        D,
        S,
    }
    public class Produtos
    {
        [PrimaryKey]
        [MaxLength(8)]
        public string Codigo_int { get; set; }
        [MaxLength(20)]
        public string Codigo_fab { get; set; }
        [MaxLength(20)]
        public string Codigo_bar { get; set; }
        [MaxLength(70)]
        public string Descricao { get; set; }
        [MaxLength(500)]
        public string Aplicacao { get; set; }
        [MaxLength(2)]
        public string Unidade_medida { get; set; }
        public double? Qtd { get; set; }
        public bool? Controla_num_serie { get; set; }
        public double? Estoque { get; set; }
        public bool? Produto_em_promocao { get; set; }
        public float? P_venda { get; set; }
        public float? Custo_reposicao { get; set; }
        public float? Custo_medio { get; set; }
        public double? Tributos_federais { get; set; }
        public DateTime? Data_cadastro { get; set; }
        public int? Usuario_cadastro { get; set; }
        public DateTime? Data_alteracao { get; set; }
        public int? Usuario_alteracao { get; set; }
        public int? Prazo_entrega { get; set; }
        public int? Pontuacao_a { get; set; }
        public int? Pontuacao_e { get; set; }
        public int? Pontuacao_v { get; set; }
        public short? Aceita_desconto { get; set; }
        public float? Desc_v { get; set; }
        public float? Desc_s { get; set; }
        public float? Desc_g { get; set; }
        [MaxLength(3)]
        public string Nivel1 { get; set; }
        [MaxLength(3)]
        public string Nivel2 { get; set; }
        [MaxLength(3)]
        public string Nivel3 { get; set; }
        [MaxLength(3)]
        public string Nivel4 { get; set; }
        [MaxLength(3)]
        public string Nivel5 { get; set; }
        [MaxLength(200)]
        public string Isbn { get; set; }
        public double? Preco_promocional { get; set; }
        public int? CodAutor { get; set; }
        public int? Serie { get; set; }
        public bool? Alterado { get; set; }
        public bool? Alterado_venda { get; set; }
        public float? Custo_alterado { get; set; }
        public float? P_venda_alterado { get; set; }
        public bool? Cesta_basica { get; set; }
        public bool? Produto_web { get; set; }
        [MaxLength(1)]
        public Situacao Situacao { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual Niveis Niveis { get; set; }
        public virtual ICollection<Produtos_Grade> Produtos_Grade { get; set; }
        public virtual ICollection<Produtos_Num_Serie> Produtos_Num_Serie { get; set; }
       // public virtual ICollection<Pedido_Venda_Prod> Pedido_Venda_Prod { get; set; }

    }

}
