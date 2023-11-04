using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        [Route("Login")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
