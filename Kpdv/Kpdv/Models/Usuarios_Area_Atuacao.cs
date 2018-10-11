using System;
using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public partial class Usuarios_Area_Atuacao
    {
        [PrimaryKey]
        public int? CodUsuario { get; set; }
        [PrimaryKey]
        public int? CodArea { get; set; }
      
        public virtual Area_Atuacao AreaAtuacao { get; set; }
        public virtual Usuarios Usuarios { get; set; }

    }
 
}
