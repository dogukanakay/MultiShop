using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("categories?id=" + id);
            return responseMessage;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("categories");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/"+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return values;
        }

        public async Task<UpdateCategoryDto> GetByIdCategoryToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
            return responseMessage;
        }
    }
}
