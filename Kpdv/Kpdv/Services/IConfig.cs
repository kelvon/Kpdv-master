using SQLite.Net.Interop;
using System;
namespace BackOn.Services
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
        ISQLitePlatform Plataforma {get; }
    }
}

