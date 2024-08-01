using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto);
        Task<HttpResponseMessage> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<HttpResponseMessage> DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<UpdateProductDto> GetByIdProductToUpdateAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
    }
}
