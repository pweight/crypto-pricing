using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using crypto_pricing.Models.CoinMarketcap;

namespace crypto_pricing.Services
{
    public class CoinMarketcapService : ICoinMarketcapService
    {
        private readonly HttpClient _httpClient;

        public CoinMarketcapService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<CoinMarketCapBaseResponse<CoinData>> GetPriceForTokenAsync(string token)
        {

            var uri = (_httpClient.BaseAddress != null ? new Uri(_httpClient.BaseAddress, $"v2/cryptocurrency/quotes/latest?symbol={token}") : null)
                ?? throw new InvalidOperationException("Base address is not set on the HttpClient instance");

            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var responseDeserialized = JsonSerializer.Deserialize<CoinMarketCapBaseResponse<CoinData>>(responseBody)
                ?? throw new JsonException("Failed to deserialize the response.");
            Console.WriteLine(responseDeserialized);

            // Console.WriteLine(responseBody);
            return responseDeserialized;; 
        }
    }
}