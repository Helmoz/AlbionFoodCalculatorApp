using System.Threading.Tasks;
using AlbionFoodCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using AlbionFoodCalculator.Services;
using System;

namespace AlbionFoodCalculator.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        public FoodItemPriceService FoodItemPriceService { get; set; }

        public PriceController(FoodItemPriceService foodItemPriceService)
        {
            FoodItemPriceService = foodItemPriceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFoodItemInfo([FromQuery] string name, [FromQuery] string city)
        {
            try
            {
                return Ok(await FoodItemPriceService.GetFoodItemInfo(name, city));
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
