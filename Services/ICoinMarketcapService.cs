namespace crypto_pricing.Services
{
    public interface ICoinMarketcapService
    {
        Task<string> GetPriceForTokenAsync(string token);
    }
}