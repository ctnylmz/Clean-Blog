using Clean_Blog.Areas.Admin.Models;
using Clean_Blog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly CleanBlogContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, CleanBlogContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [Route("Admin")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Route("/Admin/Profile")]
        public async Task<IActionResult> Profile()
        {
            return View();

        }



    [Route("/Admin/Profile")]
        [HttpPost]
        public async Task<IActionResult> Profile(Password password)
        {
            if (ModelState.IsValid)
            {
                if (password.NewPassword == password.ConfirmPassword)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, password.currentPassword, password.NewPassword);
                    if (changePasswordResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("currentPassword", "Eski Şifre Hatalı");
                    }
                }
                else
                {
                    ModelState.AddModelError("currentPassword", "Yeni Şife ve Tekrar Şifre Hatalı");
                }
            }
            
            return View();

        }

    }
}
