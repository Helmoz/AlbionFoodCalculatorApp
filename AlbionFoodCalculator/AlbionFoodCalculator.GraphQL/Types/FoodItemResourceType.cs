using AlbionFoodCalculator.Models;
using GraphQL.Types;

namespace AlbionFoodCalculator.GQL.Types
{
    public class FoodItemResourceType  : ObjectGraphType<FoodItemResourceDto>
    {
        public FoodItemResourceType()
        { 
            Field(f => f.Count);
            Field(f => f.Price);
            Field(f => f.Name);
        }
    }
}
