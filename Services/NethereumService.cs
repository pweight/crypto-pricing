using crypto_pricing.Services;
using Nethereum.Web3;

public class NethereumService : INethereumService
{
    private readonly IWeb3 _web3;

    public NethereumService(string infuraApiKey)
    {
        _web3 = new Web3($"https://mainnet.infura.io/v3/{infuraApiKey}");
    }

    public async Task<decimal> GetAccountBalanceAsync(string address)
    {
        var balance = await _web3.Eth.GetBalance.SendRequestAsync(address);
        return Web3.Convert.FromWei(balance.Value);
    }
}