using AspNetCoreHero.ToastNotification.Abstractions;
using CleanBlog.Models;
using CleanBlog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;   
        private readonly SignInManager<ApplicationUser> _signInManager;   
        private readonly INotyfService _notification;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, INotyfService notification)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _notification = notification;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }

            var existingUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == vm.Username);

            if (existingUser == null)
            {
                _notification.Error("Kullanıcı Adı Bulunamadı!");
                return View(vm);

            }

            var verifyPassword = await _userManager.CheckPasswordAsync(existingUser,vm.Password);

            if (!verifyPassword)
            {
                _notification.Error("Şifre Hatalı!");
                return View(vm);
            }

        
            await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, vm.RememberMe, true);

            return RedirectToAction("Index","User",new {area="Admin"});
        }
    }
}
