namespace CryptoPricing.Models.ApiModels;

public class GetPriceRequest
{
    public string Token { get; set; } = default!;
    public string Address { get; set; } = default!;
}
