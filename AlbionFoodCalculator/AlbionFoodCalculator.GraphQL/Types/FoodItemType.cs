using AlbionFoodCalculator.Models;
using GraphQL.Types;

namespace AlbionFoodCalculator.GQL.Types
{
    public class FoodItemType : ObjectGraphType<FoodItemDto>
    {
        public FoodItemType()
        {
            Field(f => f.Name);
            Field(f => f.CraftingFocus);
            Field(f => f.MaximalBuyPrice);
            Field(f => f.MaximalBuyPriceDate, type: typeof(DateTimeGraphType));
            Field(f => f.MinimalSellPrice);
            Field(f => f.MinimalSellPriceDate, type: typeof(DateTimeGraphType));
            Field(f => f.Cost);
            Field(f => f.Income);
            Field(f => f.Profit);
        }
    }
}
