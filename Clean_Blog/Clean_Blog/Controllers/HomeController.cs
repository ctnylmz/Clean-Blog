using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
