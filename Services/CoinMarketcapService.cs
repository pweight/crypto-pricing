using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace crypto_pricing.Services
{
    public class CoinMarketcapService : ICoinMarketcapService
    {
        private readonly HttpClient _httpClient;

        public CoinMarketcapService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetPriceForTokenAsync(string token)
        {

            var uri = (_httpClient.BaseAddress != null ? new Uri(_httpClient.BaseAddress, $"v2/cryptocurrency/quotes/latest?symbol={token}") : null)
              ?? throw new InvalidOperationException("Base address is not set on the HttpClient instance");

            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
            return responseBody; 
        }
    }
}