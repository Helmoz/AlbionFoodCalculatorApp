using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Newtonsoft.Json;
namespace AlbionFoodCalculator.Models
{
    public class FoodItemResource
    {
        [NotMapped]
        [JsonIgnore]
        public static readonly Func<FoodItemResource, FoodItemResourceDto> ProjectionExpression = foodItemResource =>
            new FoodItemResourceDto
            {
                Name = foodItemResource.Resource.Name,
                Count = foodItemResource.Count,
                Resource = new ResourceDto() { Name = foodItemResource.Resource.Name}

            };

        public long Id { get; set; }

        public virtual FoodItem FoodItem { get; set; }

        public string FoodItemName { get; set; }

        public virtual Resource Resource { get; set; }

        public string ResourceName { get; set; }

        public int Count { get; set; }
    }

    public class FoodItemResourceDto
    {
        [JsonIgnore]
        public ResourceDto Resource { get; set; }

        public int Price { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
