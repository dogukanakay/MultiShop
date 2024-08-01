using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
        Task<HttpResponseMessage> CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task<HttpResponseMessage> UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task<HttpResponseMessage> DeleteFeatureAsync(string id);
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
        Task<UpdateFeatureDto> GetByIdFeatureToUpdateAsync(string id);
    }
}
