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
    public async Task<ActionResult<PriceAndBalance>> Get(string token, string address)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return BadRequest("Token is required");
        }

        var price = await _coinMarketcapService.GetPriceForTokenAsync(token);
        var balance = await _nethereumService.GetAccountBalanceAsync(address);

        return Ok(new PriceAndBalance
        {
            Token = token,
            Price = 9.00m, //price.Data.FirstOrDefault(x => x.Key == token).Value.FirstOrDefault().Quote.FirstOrDefault().Value.Price,
            Balance = balance
        });
    }
}

public class PriceAndBalance
{
    public string Token { get; set; }
    public decimal Price { get; set; }
    public decimal Balance { get; set; }
}
