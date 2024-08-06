using MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShop.WebUI.Services.UserIdentityService
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDto>> GetAllUserListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("/api/users/getalluserslist");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserDto>>();
            return values;
        }
    }
}
