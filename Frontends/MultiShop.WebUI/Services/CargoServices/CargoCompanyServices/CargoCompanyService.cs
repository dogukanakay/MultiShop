using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargocompanies", createCargoCompanyDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCargoCompanyAsync(int cargoCompanyId)
        {
            var responseMessage = await _httpClient.DeleteAsync("cargocompanies?id=" + cargoCompanyId);
            return responseMessage;
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargocompanies");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();
            return values;
        }

        public async Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(int cargoCompanyId)
        {
            var responseMessage = await _httpClient.GetAsync("cargocompanies/"+cargoCompanyId);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoCompanyDto>();
            return values;
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyToUpdateAsync(int cargoCompanyId)
        {
            var responseMessage = await _httpClient.GetAsync("cargocompanies/" + cargoCompanyId);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargocompanies", updateCargoCompanyDto);
            return responseMessage;
        }
    }
}
