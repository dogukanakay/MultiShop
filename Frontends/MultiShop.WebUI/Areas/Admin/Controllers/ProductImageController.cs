using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly string myProductImageApi = "https://localhost:7186/api/productimages";
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("ProductImages/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductImages(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Resim Listesi";
            ViewBag.v0 = "Ürün Resim İşlemleri";
            ViewBag.x = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(myProductImageApi+"/getbyproductid/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CreateProductImage/{id}")]
        [HttpGet]
        public IActionResult CreateProductImage(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Resim Ekleme";
            ViewBag.v0 = "Ürün Resim İşlemleri";
            ViewBag.x = id;
            return View();
        }

        [Route("CreateProductImage/{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto,string id)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductImageDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(myProductImageApi, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductImages", "ProductImage", new { area = "Admin", id });
            }
            return View();
        }
        [Route("DeleteProductImage/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(myProductImageApi + "?id=" + id);
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
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Resim Güncelleme";
            ViewBag.v0 = "Ürün Resim İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(myProductImageApi + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateProductImage/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var id = updateProductImageDto.ProductId;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(myProductImageApi, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductImages", "ProductImage", new { area = "Admin",id });
            }
            return View();
        }
    }
}
