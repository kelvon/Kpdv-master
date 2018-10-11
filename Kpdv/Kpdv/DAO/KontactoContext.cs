using System;
using System.Collections.Generic;
using System.Text;
using BackOn.Models;
using Microsoft.EntityFrameworkCore;

namespace Kpdv.DAO
{
    public class KontactoContext : DbContext
    {
        private string _databasePath;
        public KontactoContext(string databasePath)
        {
            _databasePath = databasePath;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

    }
}
