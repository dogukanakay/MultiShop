using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
            return responseMessage;
        }

        public async Task<List<GetAddressesByUserIdDto>> GetAddressesByUserId(string userId)
        {
            var responseMessage = await _httpClient.GetAsync("addresses/GetAddressListByUserId/" + userId);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetAddressesByUserIdDto>>();
            return values;
        }
    }
}
