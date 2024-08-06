using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public MessageController(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public async Task<IActionResult> Inbox()
        {
            var userInfo = await _userService.GetUserInfo();
            var values = await _messageService.GetInboxMessagesAsync(userInfo.Id);
            return View(values);
        }

        public async Task<IActionResult> Sendbox()
        {
            var userInfo = await _userService.GetUserInfo();
            var values = await _messageService.GetSendboxMessagesAsync(userInfo.Id);
            return View(values);
        }
    }
}
