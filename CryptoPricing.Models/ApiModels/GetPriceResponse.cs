namespace CryptoPricing.Models.ApiModels
{
    public class GetPriceResponse
    {
        public string Token { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal Balance { get; set; }
    }
}
