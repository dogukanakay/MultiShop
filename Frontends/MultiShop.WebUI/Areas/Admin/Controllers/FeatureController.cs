using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        void FeatureViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Alan";
            ViewBag.v3 = "Öne Çıkan Alan Listesi";
            ViewBag.v0 = "Öne Çıkan Alan İşlemleri";
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            FeatureViewBagList();

            var values = await _featureService.GetAllFeaturesAsync();
            return View(values);

        }

        [Route("CreateFeature")]
        [HttpGet]
        public IActionResult CreateFeature()
        {
            FeatureViewBagList();
            return View();
        }

        [Route("CreateFeature")]
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {

            var responseMessage = await _featureService.CreateFeatureAsync(createFeatureDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {

            var responseMessage = await _featureService.DeleteFeatureAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }


        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            FeatureViewBagList();

            var values = await _featureService.GetByIdFeatureToUpdateAsync(id);
            return View(values);

        }

        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {

          
            var responseMessage = await _featureService.UpdateFeatureAsync(updateFeatureDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}
