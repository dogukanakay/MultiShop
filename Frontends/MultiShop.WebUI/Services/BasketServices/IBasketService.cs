using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync();
        Task<HttpResponseMessage> SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task<HttpResponseMessage> DeleteBasketAsync();
        Task<HttpResponseMessage> AddBasketItemAsync(BasketItemDto basketItemDto);
        Task<HttpResponseMessage> RemoveBasketItemAsync(string productId);
    }
}
