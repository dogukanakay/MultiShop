using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("offerdiscounts", createOfferDiscountDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteOfferDiscountAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("offerdiscounts?id=" + id);
            return responseMessage;
        }



        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("offerdiscounts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOfferDiscountDto>>();
            return values;
        }

        public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("offerdiscounts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdOfferDiscountDto>();
            return values;
        }

        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("offerdiscounts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateOfferDiscountDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("offerdiscounts", updateOfferDiscountDto);
            return responseMessage;
        }
    }
}
