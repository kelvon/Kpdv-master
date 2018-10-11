using Kpdv.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackOn.DAO
{
    class Usuarios_Dao
    {
        private SQLiteConnection conSQLite;

        /// <summary>
        ///  Discriptografa Frase
        /// </summary>
        /// <param name="Pass_Frase">Frase Criptografada</param>
        /// <returns>Frase discripgrafado</returns>
        public string Discriptografa_Frase(string Pass_Frase)
        {
            string Frase = "";

            if (!string.IsNullOrEmpty(Pass_Frase))
            {
                //Encripta a Senha
                int Tam = (Pass_Frase.Trim()).Length;
                for (int i = 0; i <= Tam - 1; i++)
                {
                      Frase += Convert.ToChar(Convert.ToInt32(Pass_Frase.Substring(i, 1)) - 3);
                }
            }
            return Frase;
        }
        /// <summary>
        /// Criptografa Frase
        /// </summary>
        /// <param name="Pass_Frase">Frase à ser criptografada</param>
        /// <returns>Frase criptografada</returns>
        public string Criptografa_Frase(string Pass_Frase)
        {
            string Frase = "";
            if (!string.IsNullOrEmpty(Pass_Frase))
            {
                //Encripta a Senha
                int Tam = (Pass_Frase.Trim()).Length;
                for (int i = 0; i <= Tam - 1; i++)
                {
                    Frase += Convert.ToChar(Convert.ToInt32(Pass_Frase.Substring(i, 1)) + 3);
                }
            }
            return Frase;
        }
        
        public Usuarios_Dao()
        {
            //Conexão com o banco SQLite
            ConDB conDB = new ConDB();
            conSQLite = conDB.RetCon();
            conSQLite.CreateTable<Usuarios>();
        }

        /// <summary>
        /// Inclui ou Altera o objeto Usuarios
        /// </summary>
        /// <param name="usuario">Objeto Usuarios</param>
        public int GravaUsuario(Usuarios usuario, bool altera)
        {
            int codigo;
            if (altera)
            {
                codigo = conSQLite.Update(usuario);
            }
            else
            {
                codigo = conSQLite.Insert(usuario);
            }
            return codigo;
        }

        /// <summary>
        /// Deleta o objeto Usuarios
        /// </summary>
        /// <param name="usuarios">Objeto Usuarios</param>
        public void DeletaUsuario()
        {
            //int cod = conSQLite.DropTable<Usuarios>();
            int cod =  conSQLite.DeleteAll<Usuarios>();
            // conSQLite.Delete(usuario);
        }
        /// <summary>
        /// Retorna todas as Usuarios
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
      // public List<Usuarios> GetUsuarios()
      // {
      //     return conSQLite.Table<Usuarios>().ToList();
      // }
        /// <summary>
        /// Retorna o o usuário pelo seu CodiNome
        /// </summary>
        /// <param name="codiNome">CodiNome do Usuario</param>
        /// <returns></returns>
        public Usuarios GetUsuario(string codiNome)
        {
            if (codiNome == "")
            {
                return conSQLite.Table<Usuarios>().FirstOrDefault();
            }
            else
            {
                return conSQLite.Table<Usuarios>().FirstOrDefault(c => c.Usuario == codiNome);
            }
            
        }
        
    }
}

