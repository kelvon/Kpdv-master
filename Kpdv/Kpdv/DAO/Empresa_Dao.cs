using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using SQLite.Net;
using Kpdv.Models;
using System.Collections.ObjectModel;

namespace BackOn.DAO
{
    public class Empresa_Dao 
    {
        private SQLiteConnection conSQLite;

        public Empresa_Dao()
        {
            //Conexão com o banco SQLite
            ConDB conDB = new ConDB();
            conSQLite = conDB.RetCon();
            conSQLite.CreateTable<Empresas>();
        }
               
        /// <summary>
        /// Inclui ou Altera o objeto Conexoes
        /// </summary>
        /// <param name="empresa">Objeto Conexoes</param>
        public int GravaEmpresa(Empresas empresa)
        {
            if (empresa.Id != 0)
            {
                return conSQLite.Update(empresa);
            }
            else
            {
                return conSQLite.Insert(empresa);
            }
                      
        }

        /// <summary>
        /// Deleta o objeto Conexoes
        /// </summary>
        /// <param name="empresa">Objeto Conexoes</param>
        public void DeletaEmpresa(Empresas empresa)
        {
            conSQLite.Delete(empresa);
        }
        /// <summary>
        /// Retorna todas as Conexoes
        /// </summary>
        /// <returns>Lista de Conexoes</returns>
        public List<Empresas> GetEmpresas()
        {
            var Conexoes = conSQLite.Table<Empresas>().ToList();
           return Conexoes;
        }
        /// <summary>
        /// Retorna o objeto Conexoes
        /// </summary>
        /// <param name="id">Codigo da Conexao</param>
        /// <returns>Objeto Conexão</returns>
        public Empresas GetEmpresas(int id)
        {
            return conSQLite.Table<Empresas>().FirstOrDefault(c => c.Id == id);
        }
        /// <summary>
        /// Retorna o objeto Conexoes
        /// </summary>
        /// <param name="nome">Nome da Conexão</param>
        /// <returns>Objeto Conexão</returns>
        public Empresas GetEmpresas(string nome)
        {
            return conSQLite.Table<Empresas>().FirstOrDefault(c => c.Razao == nome);
        }
    }
}
