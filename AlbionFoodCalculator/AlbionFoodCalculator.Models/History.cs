using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AlbionFoodCalculator.Models
{
    public class History
    {
        [JsonProperty("data")]
        public MarketHistoryResponse Data { get; set; }
    }

    public class MarketHistoryResponse
    {
        [JsonProperty("item_count")]
        public List<ulong> ItemCount { get; set; }

        [JsonProperty("prices_avg")]
        public List<decimal> PricesAverage { get; set; }

        [JsonProperty("timestamps")]
        public List<DateTime> Timestamps { get; set; }
    }
}
