using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }



        public async Task<IActionResult> Index()
        {
            ViewBag.Directory1 = "Ana Sayfa";
            ViewBag.Directory2 = "Sepetim";
            ViewBag.Directory3 = "Sepet İçeriğim";
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductImageUrl = values.ImageUrl,
                Price = values.ProductPrice,
                Quantity = 1
            };

            var responseMessage = await _basketService.AddBasketItemAsync(items);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItemAsync(id);

            return RedirectToAction("Index");

        }
    }
}
