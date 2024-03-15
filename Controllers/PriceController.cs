using crypto_pricing.Services;
using Microsoft.AspNetCore.Mvc;

namespace crypto_pricing.Controllers;

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
    public async Task<ActionResult<string>> Get(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return BadRequest("Token is required");
        }

        var price = await _coinMarketcapService.GetPriceForTokenAsync(token);
        var balance = await _nethereumService.GetAccountBalanceAsync("0x8e4d8e3d7f3f0f0f0f0f0f0f0f0f0f0f0f0f0f0f");
        return Ok(price);
    }
}
