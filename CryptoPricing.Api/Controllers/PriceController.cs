using crypto_pricing.Services;
using Microsoft.AspNetCore.Mvc;
using CryptoPricing.Models.ApiModels;

namespace CryptoPricing.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceController : ControllerBase
{
    private readonly ILogger<PriceController> _logger;
    private readonly ICoinMarketcapService _coinMarketcapService;
    private readonly INethereumService _nethereumService;

    public PriceController(ILogger<PriceController> logger, ICoinMarketcapService coinMarketcapService, INethereumService nethereumService)
    {
        _logger = logger;
        _coinMarketcapService = coinMarketcapService;
        _nethereumService = nethereumService;
    }

    [HttpGet(Name = "GetTokenPrice")]
    public async Task<ActionResult<GetPriceResponse>> Get(string token, string address)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return BadRequest("Token is required");
        }

        var price = await _coinMarketcapService.GetPriceForTokenAsync(token);
        var balance = await _nethereumService.GetAccountBalanceAsync(address);

        var priceData = price.Data.FirstOrDefault(d => d.Key.Equals(token, StringComparison.InvariantCultureIgnoreCase)).Value;
        var quoteData = priceData?.FirstOrDefault()?.Quote?.FirstOrDefault(q => q.Key.Equals("USD", StringComparison.InvariantCultureIgnoreCase)).Value;
        if (quoteData != null)
        {
            return Ok(new GetPriceResponse
            {
                Token = token,
                Price = quoteData.Price ?? 0m,
                Balance = balance
            });
        }
        else
        {
            return NotFound("Price data not found");
        }
    }
}
// SWITCH: CMC ID: 24302
