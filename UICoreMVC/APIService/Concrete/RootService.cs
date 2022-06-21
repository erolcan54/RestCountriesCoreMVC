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
    public class RootService : IRootService
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
                                    (item.topLevelDomain.Count > 0 && item.topLevelDomain.Contains(key.ToLower())) ||
                                    (!string.IsNullOrEmpty(item.alpha2Code) && item.alpha2Code.ToLower().Contains(key.ToLower())) ||
                                    (!string.IsNullOrEmpty(item.alpha3Code) && item.alpha3Code.ToLower().Contains(key.ToLower())) ||
                                    (item.callingCodes.Count > 0 && item.callingCodes.Contains(key.ToLower())) ||

                                    //altSpellings alanı olmayan veriler var
                                    //(item.altSpellings.Count > 0 && item.altSpellings.Contains(key.ToLower())) ||

                                    (!string.IsNullOrEmpty(item.subregion) && item.subregion.ToLower().Contains(key.ToLower())) ||
                                    (item.population != 0 && Convert.ToString(item.population) == key) ||

                                    //latlng alanı olmayan veriler var
                                    //(item.latlng.Count > 0 && item.latlng.Contains(Convert.ToDouble(key)))

                                    (!string.IsNullOrEmpty(item.demonym) && item.demonym.ToLower().Contains(key.ToLower())) ||
                                    (item.area != 0 && Convert.ToString(item.area) == key) ||
                                    (item.timezones.Count > 0 && item.timezones.Contains(key.ToLower())) ||

                                    //borders alanı olmayan veriler var
                                    //(item.borders.Count > 0 && item.borders.Contains(key.ToLower())) ||

                                    (!string.IsNullOrEmpty(item.nativeName) && item.nativeName.ToLower().Contains(key.ToLower())) ||
                                    (!string.IsNullOrEmpty(item.numericCode) && item.numericCode.Contains(key)) ||
                                    (!string.IsNullOrEmpty(item.flags.png) && item.flags.png.ToLower().Contains(key.ToLower())) ||
                                    (!string.IsNullOrEmpty(item.flags.svg) && item.flags.svg.ToLower().Contains(key.ToLower()))

                                     //Bu kısımdaki arama kodlarını yazmakta zorlandım. Hem Currencies hemde dizi şeklinde olması zorlanma sebebim oldu.
                                     //(!item.currencies.Where(a => a.name.ToLower().Contains(key.ToLower())).Select(a=>a.name).Any())

                                     //Bu kısımdaki arama kodlarını yazmakta zorlandım. Hem Language hemde dizi şeklinde olması zorlanma sebebim oldu.
                                     //(!item.languages.Where(a => a.name.ToLower().Contains(key.ToLower())).Select(a=>a.name).Any())

                                     

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
