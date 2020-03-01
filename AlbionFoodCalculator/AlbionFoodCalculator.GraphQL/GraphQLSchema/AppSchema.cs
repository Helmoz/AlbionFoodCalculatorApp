using AlbionFoodCalculator.GQL.Queries;
using AlbionFoodCalculator.Services;
using GraphQL;
using GraphQL.Types;

namespace AlbionFoodCalculator.GQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver, FoodItemPriceService foodItemPriceService) : base(resolver)
        {
            Query = new AppQuery(foodItemPriceService);
        }
    }
}
