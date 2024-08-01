using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        void OfferDiscountViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifler";
            ViewBag.v3 = "İndirim teklif ve Günün indirimi";
            ViewBag.v0 = "İndirim teklif işlemleri";

        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            OfferDiscountViewBagList();

            var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
            return View(values);

        }

        [Route("CreateOfferDiscount")]
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewBagList();
            return View();
        }

        [Route("CreateOfferDiscount")]
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {

            var responseMessage = await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {

            var responseMessage = await _offerDiscountService.DeleteOfferDiscountAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }


        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewBagList();

            var values = await _offerDiscountService.GetByIdOfferDiscountToUpdateAsync(id);
            return View(values);

        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {

           
            var responseMessage = await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }
    }
}
