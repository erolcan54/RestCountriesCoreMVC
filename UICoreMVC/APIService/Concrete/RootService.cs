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

        public async Task<List<Root>> CapitalAra(string key)
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v2/all");
            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(data);
                var filter = (from item in myDeserializedClass.ToList()
                    where !string.IsNullOrEmpty(item.capital) && item.capital.ToLower().Contains(key.ToLower())
                    select item).ToList();
                return filter;
            }
            return null;
        }

        public async Task<List<Root>> GenelArama(string key)
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v2/all");
            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(data);
                var filter = (from item in myDeserializedClass
                    where (!string.IsNullOrEmpty(item.capital) && item.capital.ToLower().Contains(key.ToLower())) ||
                          (!string.IsNullOrEmpty(item.name) && item.name.ToLower().Contains(key.ToLower())) ||
                          (!string.IsNullOrEmpty(item.region) && item.region.ToLower().Contains(key.ToLower())) ||
                          (item.topLevelDomain.Count>0 && item.topLevelDomain.Contains(key.ToLower())) ||
                          (!string.IsNullOrEmpty(item.alpha2Code) && item.alpha2Code.ToLower().Contains(key.ToLower())) ||
                          (!string.IsNullOrEmpty(item.alpha3Code) && item.alpha3Code.ToLower().Contains(key.ToLower())) ||
                          (item.callingCodes.Count > 0 && item.callingCodes.Contains(key.ToLower()))||
                          (item.altSpellings.Count > 0 && item.altSpellings.Contains(key.ToLower())) ||
                          (!string.IsNullOrEmpty(item.subregion) && item.subregion.ToLower().Contains(key.ToLower()))
                              select item).ToList();
                return filter;
            }
            return null;
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
