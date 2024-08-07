using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.OrderServices.AddressServices;
using MultiShop.WebUI.Services.UserIdentityService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly IOrderAddressService _orderAddressService;

        public UserController(IUserIdentityService userIdentityService, IOrderAddressService orderAddressService)
        {
            _userIdentityService = userIdentityService;
            _orderAddressService = orderAddressService;
        }


        public async Task<IActionResult> UserList()
        {
            var users = await _userIdentityService.GetAllUserListAsync();
            return View(users);
        }

       
        public async Task<IActionResult> UserAddresses(string id)
        {
            var addresses =await _orderAddressService.GetAddressesByUserId(id);
            return View(addresses);
        }
    }
}
