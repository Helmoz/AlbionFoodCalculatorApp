using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AlbionFoodCalculator.Database;
using AlbionFoodCalculator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace AlbionFoodCalculator.Services
{
    public class FoodItemPriceService
    {
        private IMemoryCache Chache { get; set; }

        private HttpClient HttpClient { get; set; }

        private ApplicationDbContext ApplicationDbContext { get; set; }        

        public FoodItemPriceService(IMemoryCache memoryCache, ApplicationDbContext context)
        {
            Chache = memoryCache;
            HttpClient = new HttpClient();
            ApplicationDbContext = context;
        }

        private async Task<string> GetJsonResponse(string url)
        {
            var httpResponse = await HttpClient.GetAsync(url);
            var content = await httpResponse.Content.ReadAsStringAsync();
            return content;
        }
        
        private T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T[]>(json).FirstOrDefault();
        }

        private async Task<FoodItemResponse> GetPrices(string foodItemName, string city)
        {
            var url = $"https://www.albion-online-data.com/api/v2/stats/prices/{foodItemName}?locations={city}&qualities=1";
            return new FoodItemResponse() { Json = await GetJsonResponse(url), Name = foodItemName };
        }        

        private async Task<History> GetHistory(string name, string city)
        {
            var date = DateTime.Now.AddDays(-14).ToString("MM-dd-yyyy");
            var url = $"https://www.albion-online-data.com/api/v2/stats/charts/{name}?locations={city}&date={date}&time-scale=24";

            return Deserialize<History>(await GetJsonResponse(url));
        }

        private string GetResponseByName(FoodItemResponse[] responses, string name)
        {
            return responses.FirstOrDefault(x => x.Name == name).Json;
        }

        public async Task<FoodItemDto> GetFoodItemInfo(string name, string city)
        {
            if (!Chache.TryGetValue($"{name}_{city}", out FoodItemDto item))
            {
                item = await ApplicationDbContext.FoodItems.Select(FoodItem.ProjectionExpression).FirstOrDefaultAsync(x => x.Name == name);
                item.History = await GetHistory(name, city);

                var tasks = item.Resourses.Select(x => GetPrices(x.Resource.Name, city)).ToList();
                tasks.Add(GetPrices(name, city));
                var responses = await Task.WhenAll(tasks);

                var foodItem = Deserialize<FoodItemDto>(GetResponseByName(responses, name));
                item.MinimalSellPrice = foodItem.MinimalSellPrice;
                item.MinimalSellPriceDate = foodItem.MinimalSellPriceDate.ToLocalTime();
                item.MaximalBuyPrice = foodItem.MaximalBuyPrice;
                item.MaximalBuyPriceDate = foodItem.MaximalBuyPriceDate.ToLocalTime();

                foreach (var resourse in item.Resourses)
                {
                    resourse.Resource.Price = Deserialize<FoodItemDto>(GetResponseByName(responses, resourse.Resource.Name)).MinimalSellPrice;
                }

                if (item != null)
                {
                    Chache.Set($"{name}_{city}", item, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            return item;
        }
    }
}
