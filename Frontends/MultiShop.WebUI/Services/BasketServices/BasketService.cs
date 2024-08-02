using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddBasketItemAsync(BasketItemDto basketItemDto)
        {
            var values = await GetBasketAsync();
            if (values != null)
            {
                var checkProductIsInBasket = values.BasketItems.Any(p => p.ProductId == basketItemDto.ProductId);
                if (checkProductIsInBasket)
                {
                    values.BasketItems.FirstOrDefault(p=>p.ProductId ==  basketItemDto.ProductId).Quantity +=1;
                    
                }
                else
                {
                    
                    values.BasketItems.Add(basketItemDto);
                }

            }
            return await SaveBasketAsync(values);

        }

        public async Task<HttpResponseMessage> DeleteBasketAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }

        public async Task<HttpResponseMessage> RemoveBasketItemAsync(string productId)
        {
            var values = await GetBasketAsync();
            var deletedItem = values.BasketItems.FirstOrDefault(p => p.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);
            return await SaveBasketAsync(values);
        }

        public async Task<HttpResponseMessage> SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
            return responseMessage;
        }


    }
}
