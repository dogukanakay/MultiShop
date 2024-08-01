using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features", createFeatureDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("features?id=" + id);
            return responseMessage;
        }

       

        public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("features");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureDto>>();
            return values;
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("features/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdFeatureDto>();
            return values;
        }

        public async Task<UpdateFeatureDto> GetByIdFeatureToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("features/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("features", updateFeatureDto);
            return responseMessage;
        }
    }
}
