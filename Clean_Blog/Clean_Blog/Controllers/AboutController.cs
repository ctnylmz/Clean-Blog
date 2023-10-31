using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
