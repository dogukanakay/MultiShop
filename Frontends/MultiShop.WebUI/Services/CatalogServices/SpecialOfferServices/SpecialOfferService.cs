using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createSpecialOfferDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("specialoffers?id=" + id);
            return responseMessage;
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
            return values;
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdSpecialOfferDto>();
            return values;
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateSpecialOfferDto);
            return responseMessage;
        }
    }
}
