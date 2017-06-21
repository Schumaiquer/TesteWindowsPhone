using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
   static class Client
    {
        private static HttpClient httpClient = new HttpClient();

        public static async Task<Repositorio> GetRepositorio(string uri) {
            Repositorio repositorio = null;
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode) {
                repositorio = await response.Content.ReadAsAsync<Repositorio>();
            }
            return repositorio;
        }

        }
 }
