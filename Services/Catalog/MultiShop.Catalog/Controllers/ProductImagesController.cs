using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productdetailService;

        public ProductImagesController(IProductImageService productdetailService)
        {
            _productdetailService = productdetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductImagesList()
        {
            var values = await _productdetailService.GetAllProductImagesAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var values = await _productdetailService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetByProductId/{id}")]
        public async Task<IActionResult> GetProductImagesByProductId(string id)
        {
            var values = await _productdetailService.GetProductImagesByProductIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productdetailService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün görselleri başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productdetailService.DeleteProductImageAsync(id);
            return Ok("Ürün görselleri başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productdetailService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün görselleri başarıyla güncellendi");
        }
    }
}
