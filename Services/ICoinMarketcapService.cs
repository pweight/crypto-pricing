using crypto_pricing.Models.CoinMarketcap;

namespace crypto_pricing.Services
{
    public interface ICoinMarketcapService
    {
        Task<CoinMarketCapBaseResponse<CoinData>> GetPriceForTokenAsync(string token);
    }
}