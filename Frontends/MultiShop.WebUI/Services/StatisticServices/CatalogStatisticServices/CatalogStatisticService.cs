namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetBrandCount");
            var brandCount = await responseMessage.Content.ReadFromJsonAsync<long>();
            return brandCount;
        }

        public async Task<long> GetCategoryCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetCategoryCount");
            var categoryCount = await responseMessage.Content.ReadFromJsonAsync<long>();
            return categoryCount;
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMaxPriceProductName");
            var maxPriceProductName = await responseMessage.Content.ReadAsStringAsync();
            return maxPriceProductName;
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMinPriceProductName");
            var minPriceProductName = await responseMessage.Content.ReadAsStringAsync();
            return minPriceProductName;
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductAvgPrice");
            var avgProductPrice = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return avgProductPrice;
        }

        public async Task<long> GetProductCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductCount");
            var productCount = await responseMessage.Content.ReadFromJsonAsync<long>();
            return productCount;
        }
    }
}
