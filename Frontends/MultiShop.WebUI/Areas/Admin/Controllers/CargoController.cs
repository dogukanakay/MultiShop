using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [Route("CargoCompanyList")]
        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.GetAllCargoCompaniesAsync();
            return View(values);
        }



        [Route("CreateCargoCompany")]
        [HttpGet]
        public async Task<IActionResult> CreateCargoCompany()
        {
           
            return View();
        }



        [Route("CreateCargoCompany")]
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var responseMessage = await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CargoCompanyList", "Cargo", new { Area = "Admin" });
            }
            return View();
        }

        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            var responseMessage = await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CargoCompanyList", "Cargo", new { Area = "Admin" });
            }
            return View();
        }


        [Route("UpdateCargoCompany/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var cargoCompany = await _cargoCompanyService.GetByIdCargoCompanyToUpdateAsync(id);
            return View(cargoCompany);
        }

        [Route("UpdateCargoCompany/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var responseMessage = await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CargoCompanyList", "Cargo", new { Area = "Admin" });
            }
            return View();
        }
    }
}
