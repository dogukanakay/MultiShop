using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandsAsync();
        Task<HttpResponseMessage> CreateBrandAsync(CreateBrandDto createBrandDto);
        Task<HttpResponseMessage> UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task<HttpResponseMessage> DeleteBrandAsync(string id);
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
        Task<UpdateBrandDto> GetByIdBrandToUpdateAsync(string id);
    }
}
