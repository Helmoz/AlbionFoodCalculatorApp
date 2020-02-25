using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace AlbionFoodCalculator.Models
{
    public class FoodItem
    {
        [Key]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public static readonly Expression<Func<FoodItem, FoodItemDto>> ProjectionExpression = foodItem =>
            new FoodItemDto
            {
                Name = foodItem.Name,
                CraftingFocus = foodItem.CraftingFocus,
                Resourses = foodItem.Resourses.Select(x => new FoodItemResourceDto() { Count = x.Count, Resource = new ResourceDto() { Name = x.Resource.Name } }).ToList()
            };

        public int CraftingFocus { get; set; }

        public virtual ICollection<FoodItemResource> Resourses { get; set; }
    }

    public class FoodItemDto : FoodItem
    {
        [JsonProperty("sell_price_min")]
        public int MinimalSellPrice { get; set; }

        [JsonProperty("sell_price_min_date")]
        public DateTime MinimalSellPriceDate { get; set; }

        [JsonProperty("buy_price_max")]
        public int MaximalBuyPrice { get; set; }

        [JsonProperty("buy_price_max_date")]
        public DateTime MaximalBuyPriceDate { get; set; }

        public History History { get; set; }

        public new List<FoodItemResourceDto> Resourses { get; set; }

        public string IconUrl => $"https://gameinfo.albiononline.com/api/gameinfo/items/{Name}";
    }
}
