using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync();
        Task<HttpResponseMessage> CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task<HttpResponseMessage> UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task<HttpResponseMessage> DeleteCargoCompanyAsync(int cargoCompanyId);
        Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(int cargoCompanyId);
        Task<UpdateCargoCompanyDto> GetByIdCargoCompanyToUpdateAsync(int cargoCompanyId);
    }
}
