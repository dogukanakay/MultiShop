using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task<HttpResponseMessage> CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task<HttpResponseMessage> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task<HttpResponseMessage> DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task<List<ResultProductImageDto>> GetProductImageByProductIdAsync(string id);
        Task<UpdateProductImageDto> GetByIdProductImageToUpdateAsync(string id);
    }
}
