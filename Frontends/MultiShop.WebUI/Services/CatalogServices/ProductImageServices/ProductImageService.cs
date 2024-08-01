using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createProductImageDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("productimages?id=" + id);
            return responseMessage;
        }



        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productimages");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
            return values;
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return values;
        }

        public async Task<List<ResultProductImageDto>> GetProductImageByProductIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/getbyproductid/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
            return values;
        }

        public async Task<UpdateProductImageDto> GetByIdProductImageToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimages", updateProductImageDto);
            return responseMessage;
        }
    }
}
