using Clean_Blog.Data;
using Clean_Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FooterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FooterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var footer = _context.Footers.Find(1);

            return View(footer);
        }

        [HttpPost]
        public IActionResult Index(Footer footer)
        {
            _context.Footers.Update(footer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}
