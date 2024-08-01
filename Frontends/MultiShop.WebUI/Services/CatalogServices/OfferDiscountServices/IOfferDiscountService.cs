using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync();
        Task<HttpResponseMessage> CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task<HttpResponseMessage> UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task<HttpResponseMessage> DeleteOfferDiscountAsync(string id);
        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
        Task<UpdateOfferDiscountDto> GetByIdOfferDiscountToUpdateAsync(string id);
    }
}
