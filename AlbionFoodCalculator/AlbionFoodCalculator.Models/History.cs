using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace AlbionFoodCalculator.Models
{
    public class History
    {
        [JsonProperty("data")]
        public MarketHistoryResponse Data { get; set; }

        [NotMapped]
        [JsonIgnore]
        public static readonly Func<History, HistoryDto> ProjectionExpression = history =>
            new HistoryDto
            {
                ItemCount = history.Data.ItemCount,
                PricesAverage = history.Data.PricesAverage,
                Timestamps = history.Data.Timestamps
            };
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

    public class HistoryDto
    {
        public List<ulong> ItemCount { get; set; }

        public List<decimal> PricesAverage { get; set; }

        public List<DateTime> Timestamps { get; set; }
    }
}
