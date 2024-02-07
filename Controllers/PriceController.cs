using crypto_pricing.Services;
using Microsoft.AspNetCore.Mvc;

namespace crypto_pricing.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceController : ControllerBase
{
    private readonly ILogger<PriceController> _logger;
    private readonly ICoinMarketcapService _coinMarketcapService;

    public PriceController(ILogger<PriceController> logger, ICoinMarketcapService coinMarketcapService)
    {
        _logger = logger;
        _coinMarketcapService = coinMarketcapService;
    }

    [HttpGet(Name = "GetTokenPrice")]
    public async Task<ActionResult<string>> Get(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return BadRequest("Token is required");
        }

        var price = await _coinMarketcapService.GetPriceForTokenAsync(token);
        return Ok(price);
    }
}
