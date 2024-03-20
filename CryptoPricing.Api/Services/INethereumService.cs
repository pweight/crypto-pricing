
namespace crypto_pricing.Services
{
    public interface INethereumService
    {
        Task<decimal> GetAccountBalanceAsync(string address);
    }
}