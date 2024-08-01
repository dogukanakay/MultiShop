using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateBrandDto>("brands", createBrandDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteBrandAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("brands?id=" + id);
            return responseMessage;
        }



        public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("brands");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDto>>();
            return values;
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("brands/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdBrandDto>();
            return values;
        }

        public async Task<UpdateBrandDto> GetByIdBrandToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("brands/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brands", updateBrandDto);
            return responseMessage;
        }
    }
}
