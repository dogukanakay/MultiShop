using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        void CommentViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum İşlemleri";
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CommentViewBagList();
            var values = await _commentService.GetAllCommentsAsync();
            return View(values);

        }


        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {

            var responseMessage = await _commentService.DeleteCommentAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }


        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            CommentViewBagList();

            var values = await _commentService.GetByIdCommentToUpdateAsync(id);
            return View(values);
        }

        [Route("UpdateComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {

            
            var responseMessage = await _commentService.UpdateCommentAsync(updateCommentDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
