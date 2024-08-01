using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutsAsync();
        Task<HttpResponseMessage> CreateAboutAsync(CreateAboutDto createAboutDto);
        Task<HttpResponseMessage> UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<HttpResponseMessage> DeleteAboutAsync(string id);
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
        Task<UpdateAboutDto> GetByIdAboutToUpdateAsync(string id);
    }
}
