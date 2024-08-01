using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateContactAsync(CreateContactDto createContactDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createContactDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteContactAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("contacts?id=" + id);
            return responseMessage;
        }



        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("contacts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultContactDto>>();
            return values;
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return values;
        }

        public async Task<UpdateContactDto> GetByIdContactToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateContactDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateContactDto>("contacts", updateContactDto);
            return responseMessage;
        }
    }
}
