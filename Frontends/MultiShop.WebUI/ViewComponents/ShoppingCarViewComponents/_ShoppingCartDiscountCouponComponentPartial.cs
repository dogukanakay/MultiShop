using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;
using NuGet.ContentModel;

namespace MultiShop.WebUI.ViewComponents.ShoppingCarViewComponents
{
    public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
    {

        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public _ShoppingCartDiscountCouponComponentPartial(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _basketService.GetBasketAsync();
            var tax = 10; //default, it would be change by category
            var calculatedTax= basket.TotalPrice * tax / 100;
            var totalPriceWithTax = basket.TotalPrice + calculatedTax;
            ViewBag.TaxRate = tax;
            ViewBag.Tax = calculatedTax;
            ViewBag.TotalPriceWithTax = totalPriceWithTax;
            if(basket.DiscountCode!= null)
            {
                ViewBag.DiscountRate = basket.DiscountRate;
                ViewBag.DiscountCode = basket.DiscountCode;
                ViewBag.TotalPriceWithTaxAfterDiscount = totalPriceWithTax*basket.DiscountRate/100;
            }
            return View(basket);
        }

       
       
    }
}
