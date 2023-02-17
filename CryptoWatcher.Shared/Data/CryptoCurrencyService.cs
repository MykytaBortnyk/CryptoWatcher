using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static CryptoWatcher.Shared.Data.CryptoCurrency;

namespace CryptoWatcher.Shared.Data
{
    ///<summary>
    ///Service actualy working with <see href="docs.coincap.io"/> endpoints, 
    ///for real usage should be changed to generic abstract class, with few derived servies for each API</summary>
    ///<code>
    ///abstract class Service<T> : ICryptoCurrencyService
    ///class CryptingUp : Service<OwnAsset>
    ///{Some specific behaviour}
    ///</code>
    public class CryptoCurrencyService
    {
        private readonly HttpClient _httpClient;
        public CryptoCurrencyService(HttpClient httpClient) => _httpClient = httpClient;
        public async Task<List<Asset>> GetCurrenciesAsync()
        {
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync("assets");
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeAnonymousType(
                        await response.Content.ReadAsStringAsync(), new { Data = new List<Asset>() }
                        )!.Data;
                }
            }
            catch (Exception ex) {  }
            return null;
        }
        public async Task<Asset> GetCurrencyAsync(string currencyId)
        {
            //await _httpClient.GetFromJsonAsync<Asset>($"assets/{currencyId}");
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync($"assets/{currencyId}");
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeAnonymousType(
                        await response.Content.ReadAsStringAsync(), new { Data = new Asset() }
                        )!.Data;
                }
            }
            catch (Exception ex) { }
            return null;
        }           
    }
}
