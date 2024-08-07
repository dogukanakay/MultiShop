using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCountAsync()
        {
            var values = await _statisticService.GetBrandCountAsync();
            return Ok(values);
        }

        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCountAsync()
        {
            var values = await _statisticService.GetProductCountAsync();
            return Ok(values);
        }

        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPriceAsync()
        {
            var values = await _statisticService.GetProductAvgPriceAsync();
            return Ok(values);
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCountAsync()
        {
            var values = await _statisticService.GetCategoryCountAsync();
            return Ok(values);
        }

        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductNameAsync()
        {
            var productName = await _statisticService.GetMaxPriceProductNameAsync();
            return Ok(productName);
        }

        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductNameAsync()
        {
            var productName = await _statisticService.GetMinPriceProductNameAsync();
            return Ok(productName);
        }
    }
}
