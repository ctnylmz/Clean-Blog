using Clean_Blog.Areas.Admin.Models;
using Clean_Blog.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly CleanBlogContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, CleanBlogContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            if (!HttpContext.User.Identity!.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index","Home");
                }
                else
                {

                    ModelState.AddModelError("Email", "Email Or Password Hatalı");

                    return View(model);


                }
            }
            ModelState.AddModelError("Email", "Sistemde Problem Var");
            
            return View(model);
        }

        [Route("/Admin/Logout")]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); 
            return RedirectToAction("Login", "Login"); 
        }
    }
}
