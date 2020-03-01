using System;
using System.Collections.Generic;
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

        private TOut Deserialize<TIn, TOut>(string json, Func<TIn, TOut> selector)
        {
            return JsonConvert.DeserializeObject<TIn[]>(json).Select(selector).FirstOrDefault();
        }

        private async Task<FoodItemResponse> GetPrices(string foodItemName, string city)
        {
            var url = $"https://www.albion-online-data.com/api/v2/stats/prices/{foodItemName}?locations={city}&qualities=1";
            return new FoodItemResponse() { Json = await GetJsonResponse(url), Name = foodItemName };
        }        

        public async Task<HistoryDto> GetHistory(string name, string city)
        {

            if (!Chache.TryGetValue($"{name}_{city}_history", out HistoryDto history))
            {
                var date = DateTime.Now.AddDays(-14).ToString("MM-dd-yyyy");
                var url = $"https://www.albion-online-data.com/api/v2/stats/charts/{name}?locations={city}&date={date}&time-scale=24";
                history = Deserialize(await GetJsonResponse(url), History.ProjectionExpression);
                Chache.Set($"{name}_{city}_history", history, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            }
            return history;
        }

        private string GetResponseByName(FoodItemResponse[] responses, string name)
        {
            return responses.FirstOrDefault(x => x.Name == name).Json;
        }

        public async Task<List<FoodItemResourceDto>> GetResources(string name, string city)
        {
            if (!Chache.TryGetValue($"{name}_{city}_resources", out List<FoodItemResourceDto> resources))
            {
                resources = (await ApplicationDbContext.FoodItems
                    .Select(FoodItem.ProjectionExpression)
                    .FirstOrDefaultAsync(x => x.Name == name))
                    .Resourses;

                var tasks = resources.Select(x => GetPrices(x.Resource.Name, city)).ToList();
                var responses = await Task.WhenAll(tasks);

                foreach (var resourse in resources)
                {
                    resourse.Price = Deserialize<FoodItemDto, int>(GetResponseByName(responses, resourse.Name), x => x.MinimalSellPrice);
                }
                Chache.Set($"{name}_{city}_resources", resources, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            }

            return resources;

        }

        public async Task<FoodItemDto> GetFoodItemInfo(string name, string city)
        {
            if (!Chache.TryGetValue($"{name}_{city}_foodItem", out FoodItemDto item))
            {
                item = await ApplicationDbContext.FoodItems.Select(FoodItem.ProjectionExpression).FirstOrDefaultAsync(x => x.Name == name);
                
                var foodItem = Deserialize<FoodItemDto>((await GetPrices(name, city)).Json);
                item.MinimalSellPrice = foodItem.MinimalSellPrice;
                item.MinimalSellPriceDate = foodItem.MinimalSellPriceDate.ToLocalTime();
                item.MaximalBuyPrice = foodItem.MaximalBuyPrice;
                item.MaximalBuyPriceDate = foodItem.MaximalBuyPriceDate.ToLocalTime();
                
                if (item != null)
                {
                    Chache.Set($"{name}_{city}_foodItem", item, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            return item;
        }
    }
}
