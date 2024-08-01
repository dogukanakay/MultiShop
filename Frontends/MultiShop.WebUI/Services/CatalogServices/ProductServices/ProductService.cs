using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteProductAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("products?id=" + id);
            return responseMessage;
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
            return values;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDto>();
            return values;
        }

        public async Task<UpdateProductDto> GetByIdProductToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products/ProductListWithCategory");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            var responseMessage = await _httpClient.GetAsync("products/ProductListWithCategoryByCategoryId/"+categoryId);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
          
        }

        public async Task<HttpResponseMessage> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
            return responseMessage;
        }
    }
}
