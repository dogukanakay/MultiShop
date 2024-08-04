using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.AddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        void OrderViewBagList()
        {
            ViewBag.Directory1 = "Ana Sayfa";
            ViewBag.Directory2 = "Siparişler";
            ViewBag.Directory3 = "Adres Seçimi";
        }

        [HttpGet]
        public ActionResult Index()
        {
            OrderViewBagList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            OrderViewBagList();
            var userInfo = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = userInfo.Id;
            var responseMessage = await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Payment");
            }
            return View();
        }
    }
}
