using BackOn.Services;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BackOn.DAO 
{
    public class ConDB : IDisposable
    {
        private SQLiteConnection conSQLite;

        public SQLiteConnection RetCon()
        {
            //Conexão com o banco SQLite
            var config = DependencyService.Get<IConfig>();
            conSQLite = new SQLiteConnection(config.Plataforma, Path.Combine(config.DiretorioSQLite, "BDBackOn.db3"));
            return conSQLite;
        }  

        public void Dispose()
        {
            conSQLite.Dispose();
        }
}
}
