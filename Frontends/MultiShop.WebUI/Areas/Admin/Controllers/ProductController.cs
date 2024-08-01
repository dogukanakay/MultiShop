using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly string myProductApi = "https://localhost:7186/api/products";
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            ProductViewBagList();
            var values = await _productService.GetAllProductsAsync();
            return View(values);

        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBagList();

            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);

        }

        [Route("ProductListWithCategoryByCategoryId/{id}")]
        public async Task<IActionResult> ProductListWithCategoryByCategoryId(string id)
        {
            ProductViewBagList();

            var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View(values);

        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            ProductViewBagList();
            var values  = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoryValues = (from c in values select new SelectListItem
            {
                Text = c.CategoryName, Value = c.CategoryId
            }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }


        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            var responseMessage = await _productService.CreateProductAsync(createProductDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }


        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {

            var responseMessage = await _productService.DeleteProductAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }


        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBagList();
            var values = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoryValues = (from c in values
                                                   select new SelectListItem
                                                   {
                                                       Text = c.CategoryName,
                                                       Value = c.CategoryId
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var product = await _productService.GetByIdProductToUpdateAsync(id);
            return View(product);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            var responseMessage = await _productService.UpdateProductAsync(updateProductDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }




        void ProductViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";
        }


    }
}
