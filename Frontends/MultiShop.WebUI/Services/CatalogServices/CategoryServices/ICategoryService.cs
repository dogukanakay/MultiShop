using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<HttpResponseMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<HttpResponseMessage> DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
        Task<UpdateCategoryDto> GetByIdCategoryToUpdateAsync(string id);
    }
}
