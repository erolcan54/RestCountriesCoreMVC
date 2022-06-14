using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entities.Concrete;
using Newtonsoft.Json;
using UICoreMVC.APIService.Abstract;

namespace UICoreMVC.APIService.Concrete
{
    public class RootService:IRootService
    {
        private HttpClient _httpClient;

        public RootService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<Root>> CapitalAra(string key)
        {
            throw new NotImplementedException();
        }

        public Task<List<Root>> GenelArama(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Root>> Listele()
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v2/all");
            var data = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(data);
                return myDeserializedClass;
            }
            return null;
        }
      
    }
}
