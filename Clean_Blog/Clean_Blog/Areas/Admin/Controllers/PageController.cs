using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        [Route("/admin/home")]
        public IActionResult Home()
        {
            return View();
        }

        [Route("/admin/About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/admin/Populer")]
        public IActionResult Populer()
        {
            return View();
        }

        [Route("/admin/Contact")]
        public IActionResult Contact()
        {
            return View();
        }

       
    }
}
