using System.Text.Json.Serialization;

namespace crypto_pricing.Models.CoinMarketcap
{
    public class CoinMarketCapBaseResponse<T>
    {
        public CmcStatusBase Status { get; set; } = default!;

        public Dictionary<string, List<T>> Data { get; set; } = new Dictionary<string, List<T>>();
    }

    public class CmcStatusBase
    {
        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("error_message")]
        public string? ErrorMessage { get; set; }

        [JsonPropertyName("credit_count")]
        public int CreditCount { get; set; }
    }

    public class CoinData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = default!;

        [JsonPropertyName("slug")]
        public string Slug { get; set; } = default!;

        [JsonPropertyName("num_market_pairs")]
        public int NumMarketPairs { get; set; }

        [JsonPropertyName("date_added")]
        public DateTimeOffset DateAdded { get; set; }

        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; } = new List<Tag>();

        [JsonPropertyName("max_supply")]
        public double? MaxSupply { get; set; }

        [JsonPropertyName("circulating_supply")]
        public double CirculatingSupply { get; set; }

        [JsonPropertyName("total_supply")]
        public double TotalSupply { get; set; }

        [JsonPropertyName("is_active")]
        public int IsActive { get; set; }

        [JsonPropertyName("infinite_supply")]
        public bool InfiniteSupply { get; set; }

        [JsonPropertyName("platform")]
        public Platform? Platform { get; set; }

        [JsonPropertyName("cmc_rank")]
        public int CmcRank { get; set; }

        [JsonPropertyName("is_fiat")]
        public int IsFiat { get; set; }

        [JsonPropertyName("self_reported_circulating_supply")]
        public int? SelfReportedCirculatingSupply { get; set; }

        [JsonPropertyName("self_reported_market_cap")]
        public int? SelfReportedMarketCap { get; set; }
        // public object TvlRatio { get; set; }
        
        [JsonPropertyName("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        public Dictionary<string, Quote> Quote { get; set; } = new Dictionary<string, Quote>();
    }
    
    public class Tag
    {
        [JsonPropertyName("slug")]
        public string Slug { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("category")]
        public string Category { get; set; } = default!;
    }

    public class Platform
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = default!;

        [JsonPropertyName("slug")]
        public string Slug { get; set; } = default!;

        [JsonPropertyName("token_address")]
        public string TokenAddress { get; set; } = default!;
    }
    
    public class Quote
    {
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("volume_24h")]
        public double Volume24h { get; set; }

        [JsonPropertyName("volume_change_24h")]
        public double VolumeChange24h { get; set; }

        [JsonPropertyName("percent_change_1h")]
        public double PercentChange1h { get; set; }

        [JsonPropertyName("percent_change_24h")]
        public double PercentChange24h { get; set; }

        [JsonPropertyName("percent_change_7d")]
        public double PercentChange7d { get; set; }

        [JsonPropertyName("percent_change_30d")]
        public double PercentChange30d { get; set; }

        [JsonPropertyName("percent_change_60d")]
        public double PercentChange60d { get; set; }

        [JsonPropertyName("percent_change_90d")]
        public double PercentChange90d { get; set; }

        [JsonPropertyName("market_cap")]
        public double MarketCap { get; set; }

        [JsonPropertyName("market_cap_dominance")]
        public double MarketCapDominance { get; set; }

        [JsonPropertyName("fully_diluted_market_cap")]
        public double FullyDilutedMarketCap { get; set; }
        // public object Tvl { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}