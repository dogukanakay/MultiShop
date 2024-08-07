using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public interface IOrderAddressService
    {
        Task<HttpResponseMessage> CreateOrderAddressAsync(CreateOrderAddressDto orderAddressDto);
        Task<List<GetAddressesByUserIdDto>> GetAddressesByUserId(string userId);
    }
}
