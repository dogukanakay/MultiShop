using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {

        private readonly string myProductDetailApi = "https://localhost:7186/api/productdetails";
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("UpdateProductDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Açıklama ve Bilgi Güncelleme";
            ViewBag.v0 = "Ürün İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(myProductDetailApi + "/getproductdetailbyproductid/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateProductDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto,string id)
        {
            updateProductDetailDto.ProductId = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(myProductDetailApi, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
