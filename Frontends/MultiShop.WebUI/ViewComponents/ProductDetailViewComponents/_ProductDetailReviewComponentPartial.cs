using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly string myCommentApi = "https://localhost:7191/api/comments";
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }




        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.ProductId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(myCommentApi+"/getcommentbyproductid/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }
     
        
    }
}
