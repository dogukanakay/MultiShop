using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Discount.Dtos;
using Multishop.Discount.Services;

namespace Multishop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discoutService;

        public DiscountsController(IDiscountService discoutService)
        {
            _discoutService = discoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscountCouponsList()
        {
            var values = await _discoutService.GetAllDiscountCouponsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discoutService.GetByIdDiscountCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discoutService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("İndirim kuponu başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discoutService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("İndirim kuponu başarıyla  güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discoutService.DeleteDiscountCouponAsync(id);
            return Ok("İndirim kuponu başarıyla silindi.");
        }

    }
}
