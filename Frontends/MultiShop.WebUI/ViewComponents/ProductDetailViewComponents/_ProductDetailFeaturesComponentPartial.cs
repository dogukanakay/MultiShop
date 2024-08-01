using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeaturesComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDetailFeaturesComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var values = await _productService.GetByIdProductAsync(id);
            return View(values);

        }
    }
}
