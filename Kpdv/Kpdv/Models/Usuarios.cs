using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace Kpdv.Models
{
    public class Usuarios
    {

        [PrimaryKey]
        public int Codigo_int { get; set; }
        [MaxLength(15)]
        public string Usuario { get; set; }
        [MaxLength(10)]
        public string Senha { get; set; }
        public int Administrador { get; set; }
        public int CodGrupo { get; set; }
        public int CodArea { get; set; }
    
        [MaxLength(1)]
        public string Situacao { get; set; }
        public int Cod_funcao { get; set; }
        //public virtual ICollection<Usuarios_Area_Atuacao> Usuarios_Area_Atuacao { get; set; }

    }
   

}





