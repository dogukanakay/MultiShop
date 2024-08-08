using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService,
            IUserStatisticService userStatisticService,
            ICommentStatisticService commentStatisticService,
            IDiscountStatisticService discountStatisticService,
            IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            //catalog statistics start

            var brandCount = await _catalogStatisticService.GetBrandCountAsync();
            ViewBag.BrandCount = brandCount;

            var categoryCount = await _catalogStatisticService.GetCategoryCountAsync();
            ViewBag.CategoryCount = categoryCount;

            var productCount = await _catalogStatisticService.GetProductCountAsync();
            ViewBag.ProductCount = productCount;

            var maxPriceProduct = await _catalogStatisticService.GetMaxPriceProductNameAsync();
            ViewBag.MaxPriceProduct = maxPriceProduct;

            var minPriceProduct = await _catalogStatisticService.GetMinPriceProductNameAsync();
            ViewBag.MinPriceProduct = minPriceProduct;

            var avgProductPrice = await _catalogStatisticService.GetProductAvgPriceAsync();
            ViewBag.AvgProductPrice = avgProductPrice;

            //catalog statistics end


            //User statistics start

            var userCount = await _userStatisticService.GetUserCount();
            ViewBag.UserCount = userCount;

            //User statistics end


            //Comment statistics start

            var commentCount = await _commentStatisticService.GetCommentCount();
            ViewBag.CommentCount = commentCount;

            var activeCommentCount= await _commentStatisticService.GetActiveCommentCount();
            ViewBag.ActiveCommentCount = activeCommentCount;

            var passiveCommentCount= await _commentStatisticService.GetPassiveCommentCount();
            ViewBag.PassiveCommentCount = passiveCommentCount;

            //Comment statistics end

            //Discount statistics start

            var discountCouponCount = await _discountStatisticService.GetDiscountCouponCount();
            ViewBag.DiscountCouponCount = discountCouponCount;

            //Discount statistics end

            //Message statistics start

            var messageCount = await _messageStatisticService.GetMessageCount();
            ViewBag.MessageCount = messageCount;

            //Message statistics end

            return View();
        }
    }
}
