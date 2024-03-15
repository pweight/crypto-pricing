using crypto_pricing.Services;
using Nethereum.Web3;

public class NethereumService : INethereumService
{
    private readonly Web3 _web3;

    public NethereumService(string rpcUrl)
    {
        _web3 = new Web3(rpcUrl);
    }

    public async Task<decimal> GetAccountBalanceAsync(string address)
    {
        var balance = await _web3.Eth.GetBalance.SendRequestAsync(address);
        return Web3.Convert.FromWei(balance.Value);
    }
}