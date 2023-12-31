﻿using Clean_Blog.Data;
using Clean_Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FooterPageController : Controller
    {
        private readonly CleanBlogContext _context;

        public FooterPageController(CleanBlogContext context)
        {
            _context = context;
        }

        [Route("/Admin/Footer")]
        public IActionResult Index()
        {
            var footer = _context.Footers.FirstOrDefault();

            if (footer == null)
            {
                var newFooter = new Footer
                {
                    Link1 = "",
                    Link2 = "",
                    Link3 = "",
                    Title = ""
                };

                _context.Footers.Add(newFooter);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(footer);
        }

        [Route("/Admin/Footer")]
        [HttpPost]
        public IActionResult Index(Footer footer)
        {
            _context.Footers.Update(footer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}
