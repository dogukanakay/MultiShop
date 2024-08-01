using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.CheckIfCategory = false;
            if (!string.IsNullOrEmpty(id))
            {
                var values =await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
                ViewBag.CheckIfCategory = true;
                return View(values);
                
            }
            else
            {
                var values =await _productService.GetProductsWithCategoryAsync();
                return View(values);
            }

        }
    }
}

