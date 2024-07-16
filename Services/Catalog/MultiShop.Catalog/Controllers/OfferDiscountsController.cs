using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService offerDiscountService;

        public OfferDiscountsController(IOfferDiscountService categoryService)
        {
            offerDiscountService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesList()
        {
            var values = await offerDiscountService.GetAllOfferDiscountsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferDiscountById(string id)
        {
            var values = await offerDiscountService.GetByIdOfferDiscountAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("Özel teklif başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await offerDiscountService.DeleteOfferDiscountAsync(id);
            return Ok("Özel teklif silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("Özel teklif başarıyla güncellendi");
        }
    }
}
