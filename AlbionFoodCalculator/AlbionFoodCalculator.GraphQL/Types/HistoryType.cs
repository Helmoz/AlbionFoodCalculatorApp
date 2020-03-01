using AlbionFoodCalculator.Models;
using GraphQL.Types;

namespace AlbionFoodCalculator.GraphQL.Types
{
    public class HistoryType : ObjectGraphType<HistoryDto>
    {
        public HistoryType()
        {
            Field(h => h.ItemCount, type: typeof(ListGraphType<ULongGraphType>));
            Field(h => h.PricesAverage, type: typeof(ListGraphType<DecimalGraphType>));
            Field(h => h.Timestamps, type: typeof(ListGraphType<DateTimeGraphType>));
        }
    }
}
