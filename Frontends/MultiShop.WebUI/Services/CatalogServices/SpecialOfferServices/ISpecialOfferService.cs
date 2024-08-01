using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();
        Task<HttpResponseMessage> CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task<HttpResponseMessage> UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task<HttpResponseMessage> DeleteSpecialOfferAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
        Task<UpdateSpecialOfferDto> GetByIdSpecialOfferToUpdateAsync(string id);
    }
}
