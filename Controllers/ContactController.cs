using Clean_Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Controllers
{
    public class ContactController : Controller
    {
        private readonly CleanBlogContext _context;

        public ContactController(CleanBlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contact = _context.Pages.Find(4);
            return View(contact);
        }
    }
}
