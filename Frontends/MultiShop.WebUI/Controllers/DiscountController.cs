using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;
using NuGet.ContentModel;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<PartialViewResult> ConfirmDiscountCoupon()
        {
            
            return PartialView();
 
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCodeDetailByCode(code);
            if(values != null)
            {
                var basketValues = await _basketService.GetBasketAsync();
                basketValues.DiscountCode = values.Code;
                basketValues.DiscountRate = values.Rate;
                var responseMessage = await _basketService.SaveBasketAsync(basketValues);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "ShoppingCart");
                }
            }
            
            return RedirectToAction("Index", "ShoppingCart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveDiscountCouponFromBasket()
        {
            var basket = await _basketService.GetBasketAsync();
            basket.DiscountCode = null;
            basket.DiscountRate=null;
            var responseMessage = await _basketService.SaveBasketAsync(basket);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
