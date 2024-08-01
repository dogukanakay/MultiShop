using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync();
        Task<HttpResponseMessage> CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task<HttpResponseMessage> UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task<HttpResponseMessage> DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task<UpdateFeatureSliderDto> GetByIdFeatureSliderToUpdateAsync(string id);
        Task<HttpResponseMessage> FeatureSliderChangeStatusToTrue(string id);
        Task<HttpResponseMessage> FeatureSliderChangeStatusToFalse(string id);
    }
}
