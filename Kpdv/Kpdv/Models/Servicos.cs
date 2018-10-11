using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public class Servicos
    {
        [PrimaryKey]
        [MaxLength(8)]
        public string Codigo { get; set; }
        [MaxLength(50)]
        public string Descricao { get; set; }
        [MaxLength(8)]
        public string Codigo_mercosul { get; set; }
        [MaxLength(8)]
        public string Codigo_cest { get; set; }
        public int? Tempo_padrao { get; set; }
        public float? Valor_hora { get; set; }
        public float? Custo_hora { get; set; }
        public bool? Preco_variado { get; set; }
        public Nullable<double> Tributos_federais { get; set; }
        public short? Aceita_desconto { get; set; }
        public float? Desc_g { get; set; }
        public float? Desc_s { get; set; }
        public float? Desc_v { get; set; }
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
        public int? Pontuacao_a { get; set; }
        public int? Pontuacao_e { get; set; }
        public int? pontuacao_v { get; set; }
        public short? Paga_comissao { get; set; }
        public float? Comissao { get; set; }
        public float? Valor_comissao { get; set; }
        public float? Valor_desc_base_comissao { get; set; }
        public float? Comissao_e { get; set; }
        public float? Valor_comissao_e { get; set; }
        public float? Valor_desc_base_comissao_e { get; set; }
        public float? Comissao_a { get; set; }
        public float? Valor_comissao_a { get; set; }
        public float? Valor_desc_base_comissao_a { get; set; }
        public float? Desc_especial { get; set; }
        public short? Tipo { get; set; }
        public Nullable<int> Prazo_garantia { get; set; }
        public short? Tipo_garantia { get; set; }
        public bool? Alterado { get; set; }
        [MaxLength(2)]
        public string Cst_ipi_entrada { get; set; }
        [MaxLength(2)]
        public string cst_ipi_saida { get; set; }
        [MaxLength(3)]
        public string Cod_grupo_pis_cofins { get; set; }
        public short? Tributacao_pis { get; set; }
        public float? Perc_valor_pis { get; set; }
        public short? Tributacao_cofins { get; set; }
        public float? Perc_valor_cofins { get; set; }
        [MaxLength(5)]
        public string Cod_lista_servico { get; set; }
        [MaxLength(8)]
        public string Cod_servico_municipio { get; set; }
        public short? Tipo_tributacao { get; set; }
        [MaxLength(3)]
        public string Cod_icms { get; set; }
        public float? Valor_Comissão_E { get; set; }
        public float? Valor_Comissão_A { get; set; }
        public bool? Construcao_civil { get; set; }
        [MaxLength(1)]
        public string Situacao { get; set; }
        
           
        public virtual Niveis Niveis { get; set; }
        //public virtual ICollection<os_produto> os_produto { get; set; }
        //public virtual ICollection<Pedido_Venda_Prod> Pedido_Venda_Prod { get; set; }
        //public virtual ICollection<os_tempo> os_tempo { get; set; }
        //public virtual ICollection<servicos_func> servicos_func { get; set; }
        //public virtual ICollection<Servicos_Produtos> Servicos_Produtos { get; set; }

    }
}
