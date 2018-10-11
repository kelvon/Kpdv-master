using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Empresas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Cnpj { get; set; }
        [MaxLength(100)]
        public string Razao { get; set; }
        [MaxLength(50)]
        public string Fantazia { get; set; }
        [MaxLength(100)]
        public string UrlBase { get; set; }
        [MaxLength(50)]
        public string Servidor { get; set; }
        [MaxLength(50)]
        public string Banco { get; set; }
    }
}
