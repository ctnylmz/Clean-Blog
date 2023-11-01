using Clean_Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Controllers
{
    public class PopularController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PopularController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var populer = _context.Pages.Find(3);
            return View(populer);
        }
    }
}
