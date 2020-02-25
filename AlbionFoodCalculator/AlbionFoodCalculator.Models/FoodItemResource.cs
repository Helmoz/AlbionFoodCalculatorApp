namespace AlbionFoodCalculator.Models
{
    public class FoodItemResource
    {
        public long Id { get; set; }

        public virtual FoodItem FoodItem { get; set; }

        public string FoodItemName { get; set; }

        public virtual Resource Resource { get; set; }

        public string ResourceName { get; set; }

        public int Count { get; set; }
    }

    public class FoodItemResourceDto
    {
        public ResourceDto Resource { get; set; }

        public int Count { get; set; }
    }
}
