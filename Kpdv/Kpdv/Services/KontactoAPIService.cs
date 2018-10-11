using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kpdv.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace BackOn.Services
{
    class KontactoAPIService : IKontactoAPIService
    {
        private HttpClient httpClient = new HttpClient();

        public async Task<string> RetObjetoAsync(string BaseUrl)

        {
            try
            {
                //Uri uri = new Uri(BaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetStringAsync(BaseUrl);
                return response;
            }
            catch (Exception ex)
            {
                string mens = ex.Message;
               // await App.Current.MainPage.DisplayAlert("Back-On", mens, "OK");
                return null;
            }

        }

        

        public async Task AddObjetoAsync(string BaseUrl, Usuarios Objeto, int Id)
        {
            try
            {
                var uri = new Uri(string.Format(BaseUrl, Id));
                var data = JsonConvert.SerializeObject(Objeto);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await httpClient.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                 //   await App.Current.MainPage.DisplayAlert("Back-On", "Erro ao Incluir", "OK");
                }
            }
            catch (Exception)
            {
               // await App.Current.MainPage.DisplayAlert("Back-On", ex.Message, "OK");
            }
        }
        public async Task UpdateObjetoAsync(string BaseUrl, Usuarios Objeto, int Id)
        {
            var uri = new Uri(string.Format(BaseUrl, Id));
            var data = JsonConvert.SerializeObject(Objeto);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await httpClient.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
              //  await App.Current.MainPage.DisplayAlert("Back-On", "Erro ao Atualizar", "OK");
            }
        }
        public async Task DeletaObjetoAsync(string BaseUrl, int Id)
        {
            var uri = new Uri(string.Format(BaseUrl, Id));
            await httpClient.DeleteAsync(uri);
        }
    }
}

