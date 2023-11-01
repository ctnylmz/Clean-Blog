using Clean_Blog.Data;
using Clean_Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("/admin/home")]
        public IActionResult Home()
        {
            var home = _context.Pages.Find(1);

            return View(home);
        }


        [Route("/admin/home")]
        [HttpPost]
        public IActionResult Home(Page page)
        {
           _context.Pages.Update(page);
           _context.SaveChanges();
            return RedirectToAction("home");
        }

        [Route("/admin/About")]
        public IActionResult About()
        {
            var about = _context.Pages.Find(2);

            return View(about);
        }

        [Route("/admin/About")]
        [HttpPost]
        public IActionResult About(Page page)
        {
            _context.Pages.Update(page);
            _context.SaveChanges();
            return RedirectToAction("About");
        }

        [Route("/admin/Populer")]
        public IActionResult Populer()
        {
            var populer = _context.Pages.Find(3);

            return View(populer);
        }

        [Route("/admin/Populer")]
        [HttpPost]
        public IActionResult Populer(Page page)
        {
            _context.Pages.Update(page);
            _context.SaveChanges();
            return RedirectToAction("Populer");
        }

        [Route("/admin/Contact")]
        public IActionResult Contact()
        {
            var contact = _context.Pages.Find(4);

            return View(contact);
        }

        [Route("/admin/Contact")]
        [HttpPost]
        public IActionResult Contact(Page page)
        {
            _context.Pages.Update(page);
            _context.SaveChanges();
            return RedirectToAction("Contact");
        }


    }
}
