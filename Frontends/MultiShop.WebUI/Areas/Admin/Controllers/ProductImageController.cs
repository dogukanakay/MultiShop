using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        void ProductImageViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v0 = "Ürün Resim İşlemleri";
        }

        [Route("ProductImages/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductImages(string id)
        {
            ProductImageViewBagList();
            ViewBag.x = id;
            var values = await _productImageService.GetProductImageByProductIdAsync(id);
            return View(values);

        }

        [Route("CreateProductImage/{id}")]
        [HttpGet]
        public IActionResult CreateProductImage(string id)
        {
            ProductImageViewBagList();
            ViewBag.x = id;
            return View();
        }

        [Route("CreateProductImage/{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto, string id)
        {

            var responseMessage = await _productImageService.CreateProductImageAsync(createProductImageDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductImages", "ProductImage", new { area = "Admin", id });
            }
            return View();
        }
        [Route("DeleteProductImage/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {

            var responseMessage = await _productImageService.DeleteProductImageAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var referrerUrl = Request.Headers["Referer"].ToString();
                if (!string.IsNullOrEmpty(referrerUrl))
                {
                    return Redirect(referrerUrl);
                }
            }
            return View();
        }


        [Route("UpdateProductImage/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            ProductImageViewBagList();

            var values = await _productImageService.GetByIdProductImageToUpdateAsync(id);
            return View(values);

        }

        [Route("UpdateProductImage/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var id = updateProductImageDto.ProductId;
            var responseMessage = await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductImages", "ProductImage", new { area = "Admin", id });
            }
            return View();
        }
    }
}
