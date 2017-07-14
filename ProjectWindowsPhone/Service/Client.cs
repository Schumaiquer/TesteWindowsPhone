using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Service
{
   public static class Client
    {
        private static HttpClient httpClient = new HttpClient();

        public static async Task<List<Repositorio>> GetRepositorio(string uri) {
            List <Repositorio> repositorio = null;
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode) {
               string stringReposito = await response.Content.ReadAsStringAsync();
                var array = JObject.Parse(stringReposito)["items"];
                repositorio = JsonConvert.DeserializeObject<List<Repositorio>>(array.ToString());
            }
            return repositorio;
        }

        public static async Task<List<Pull>> GetPull(string uri){
            List<Pull> pull = null;
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string stringReposito = await response.Content.ReadAsStringAsync();
                
                pull = JsonConvert.DeserializeObject<List<Pull>>(stringReposito);
            }
            return pull;
        }

    }
 }
