using Clean_Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Controllers
{
    public class AboutController : Controller
    {
        private readonly CleanBlogContext _context;

        public AboutController(CleanBlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var about = _context.Pages.Find(2);

            return View(about);
        }
    }
}
