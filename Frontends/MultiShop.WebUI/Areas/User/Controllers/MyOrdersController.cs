﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrdersController : Controller
    {
        public IActionResult MyOrdersList()
        {
            return View();
        }
    }
}
