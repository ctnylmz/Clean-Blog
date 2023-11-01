using Clean_Blog.Data;
using Clean_Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeaderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeaderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var header = _context.Headers.Find(1);

            return View(header);
        }

        [HttpPost]
        public IActionResult Index(Header header)
        {
            if (ModelState.IsValid)
            {
                _context.Headers.Update(header);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(header);
        }
    }
}
