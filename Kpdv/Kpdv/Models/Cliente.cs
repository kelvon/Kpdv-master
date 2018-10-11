using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Cliente
    {
 
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Codigo { get; set; }
        [MaxLength(14)]
        public string Cgc_cpf { get; set; }
        [MaxLength(60)]
        public string Nome { get; set; }
        public short? Cliente_forn { get; set; }
        [MaxLength(1)]
        public string Sexo { get; set; }
        [MaxLength(30)]
        public string Fantasia { get; set; }
        [MaxLength(18)]
        public string Inscr_est { get; set; }
        [MaxLength(18)]
        public string Inscr_mun { get; set; }
        public float? Desconto { get; set; }
        public DateTime? Data_nasc { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Data_alteracao { get; set; }
        [MaxLength(2)]
        public string Tipo { get; set; }
        [MaxLength(200)]
        public string Contato { get; set; }
        [MaxLength(300)]
        public string E_mail { get; set; }
        [MaxLength(200)]
        public string Site { get; set; }
        public int? CodRegiao { get; set; }
        [MaxLength(3)]
        public string CodSegmento { get; set; }
        public int? CodRota { get; set; }
        public int? Tabela_cliente { get; set; }
        public DateTime? Ultimo_contato { get; set; }
        public bool? Credita_icms { get; set; }
        public bool? Aceita_troca { get; set; }
        public short? Dia_contato { get; set; }
        public short? Dia_entrega { get; set; }
        public int? Vendedor { get; set; }
        [MaxLength(3)]
        public string Forma_pag { get; set; }
        public short? Tabela_preco { get; set; }
        public bool? Faturamento_principal { get; set; }
        public int? Faturar { get; set; }
        public double? Limite_credito { get; set; }
        [MaxLength(500)]
        public string Historico { get; set; }
        [MaxLength(500)]
        public string Obs_cli { get; set; }
        [MaxLength(500)]
        public string Obs_pedido { get; set; }
        public int? Usuario_cadastro { get; set; }
        public int? Usuario_alteracao { get; set; }
        public bool? Alterado { get; set; }
        [MaxLength(1)]
        public string Situacao { get; set; }
        public bool? Aceita_email { get; set; }
        public short? Consumidor_final { get; set; }
        public short? Crt { get; set; }
        [MaxLength(200)]
        public string Email_NFE { get; set; }
        public short? INDPRES { get; set; }
        public short? TRIBUTA_ISS_FORA { get; set; }

        public virtual Forma_Pagamento Forma_Pagamento { get; set; }
       // public virtual Cliente Clientes { get; set; }
        public virtual Regioes Regioes { get; set; }
        public virtual Rotas Rotas { get; set; }
        public virtual Segmentos Segmentos { get; set; }
        //public virtual tipo_cliente tipo_cliente { get; set; }
       // public virtual Usuarios Usuario { get; set; }
       // public virtual ICollection<os> os { get; set; }
        public virtual ICollection<Cliente_Contato> Cliente_Contato { get; set; }
        public virtual ICollection<Cliente_End> Cliente_End { get; set; }
        public virtual ICollection<Cliente_Tel> Cliente_Tel { get; set; }
        public virtual ICollection<Pedido_Venda> Pedido_Venda { get; set; }
        public virtual ICollection<Receber> Receber { get; set; }
        //public virtual ICollection<viagem_cilindro> viagem_cilindro { get; set; }

    }
}
