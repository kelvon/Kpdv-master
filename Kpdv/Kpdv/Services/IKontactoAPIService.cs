using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kpdv.Models;


namespace BackOn.Services
{
    interface IKontactoAPIService
    {
        
        Task<string> RetObjetoAsync(string BaseUrl);
        Task AddObjetoAsync(string BaseUrl, Usuarios Objeto, int Id);
        Task UpdateObjetoAsync(string BaseUrl, Usuarios Objeto, int Id);
        Task DeletaObjetoAsync(string BaseUrl, int Id);
        
    }
}
