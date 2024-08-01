using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featuresliders", createFeatureSliderDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("featuresliders?id=" + id);
            return responseMessage;
        }

        public Task<HttpResponseMessage> FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureSliderDto>>();
            return values;
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdFeatureSliderDto>();
            return values;
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featuresliders", updateFeatureSliderDto);
            return responseMessage;
        }
    }
}
