using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactsAsync();
        Task<HttpResponseMessage> CreateContactAsync(CreateContactDto createContactDto);
        Task<HttpResponseMessage> UpdateContactAsync(UpdateContactDto updateContactDto);
        Task<HttpResponseMessage> DeleteContactAsync(string id);
        Task<UpdateContactDto> GetByIdContactToUpdateAsync(string id);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
