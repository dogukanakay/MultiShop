using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task<HttpResponseMessage> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task<HttpResponseMessage> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task<HttpResponseMessage> DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<UpdateProductDetailDto> GetByIdProductDetailToUpdateAsync(string id);
        Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
        Task<UpdateProductDetailDto> GetByProductIdProductDetailToUpdateAsync(string id);
    }
}
