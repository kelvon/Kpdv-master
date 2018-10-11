using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace Kpdv.Models
{
    public class Menus
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(60)]
        public string Nome { get; set; }
        public string Icon { get; set; }
        public string Pagina { get; set; }
    }
}
