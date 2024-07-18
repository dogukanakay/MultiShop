using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private string myProductApi = "https://localhost:7186/api/products";
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                myProductApi += "/ProductListWithCategoryByCategoryId/" + id;
            }
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(myProductApi);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

