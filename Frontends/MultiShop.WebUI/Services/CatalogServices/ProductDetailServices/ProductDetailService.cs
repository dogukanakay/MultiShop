using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetails", createProductDetailDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("productdetails?id=" + id);
            return responseMessage;
        }



        public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productdetails");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
            return values;
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return values;
        }

        public async Task<UpdateProductDetailDto> GetByIdProductDetailToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            return values;
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/getproductdetailbyproductid/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return values;
        }

        public async Task<UpdateProductDetailDto> GetByProductIdProductDetailToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/getproductdetailbyproductid/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetails", updateProductDetailDto);
            return responseMessage;
        }
    }
}
