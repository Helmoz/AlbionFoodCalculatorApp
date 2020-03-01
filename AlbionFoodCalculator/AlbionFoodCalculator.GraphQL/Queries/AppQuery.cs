using AlbionFoodCalculator.Services;
using GraphQL.Types;
using AlbionFoodCalculator.GQL.Types;
using AlbionFoodCalculator.GraphQL.Types;
using System;
using System.Collections.Generic;
using AlbionFoodCalculator.Models;
using System.Threading.Tasks;

namespace AlbionFoodCalculator.GQL.Queries
{
    public class AppQuery : ObjectGraphType
    {
        private static QueryArguments Arguments => new QueryArguments(
            new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
            new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "city" });

        private FieldType GetField<T, TDto>(string fieldName, Func<string, string, Task<TDto>> serviceMethod) where T : IGraphType
        {
            return Field<T>(fieldName,
                arguments: Arguments,
                resolve: ctx =>
                {
                    var name = ctx.GetArgument<string>(Arguments[0].Name);
                    var city = ctx.GetArgument<string>(Arguments[1].Name);
                    return serviceMethod(name, city);
                });
        }

        public AppQuery(FoodItemPriceService foodItemPriceService)
        {
            GetField<FoodItemType, FoodItemDto>("foodItem", foodItemPriceService.GetFoodItemInfo);
            GetField<HistoryType, HistoryDto>("history", foodItemPriceService.GetHistory);
            GetField<ListGraphType<FoodItemResourceType>, List<FoodItemResourceDto>>("resources", foodItemPriceService.GetResources);            
        }
    }
}