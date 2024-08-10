using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.WebUI.Services.Interfaces;


namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var token = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            token = token.Replace("\"", "");
            ViewBag.AccessToken = token;
            var userInfo = await _userService.GetUserInfo();
            ViewBag.UserId = userInfo.Id;
            return View();
        }
    }
}
