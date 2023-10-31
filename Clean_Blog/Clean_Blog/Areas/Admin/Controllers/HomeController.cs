using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Route("/Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
