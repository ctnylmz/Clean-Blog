﻿using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
