using Clean_Blog.Data;
using Clean_Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeaderController : Controller
    {
        private readonly CleanBlogContext _context;

        public HeaderController(CleanBlogContext context)
        {
            _context = context;
        }


        [Route("/Admin/Header")]
        public IActionResult Index()
        {
            var header = _context.Headers.FirstOrDefault();

            if (header == null)
            {
                var newHeader = new Header
                {
                    Title = "",
                    Menu1 = "",
                    Menu2 = "",
                    Menu3 = "",
                    Menu4 = "",
                    Menu5 = ""
                };

                _context.Headers.Add(newHeader);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(header);
        }


        [Route("/Admin/Header")]
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
