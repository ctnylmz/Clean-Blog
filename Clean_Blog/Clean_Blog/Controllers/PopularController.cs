using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Controllers
{
    public class PopularController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
