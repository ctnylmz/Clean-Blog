using Clean_Blog.Areas.Admin.Models;
using Clean_Blog.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly CleanBlogContext _context;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, CleanBlogContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [Route("/Admin/User")]
        public async Task<IActionResult> user()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoles = new Dictionary<string, string>();

            foreach (var user in users)
            {
                var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id);
                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);

                // Kullanıcının rolü
                var roleName = role.Name;
                userRoles[user.Id] = roleName; // Store the role for each user
            }
            ViewBag.UserRoles = userRoles;
            return View(users);
        }





        [Route("/Admin/Register")]
        public IActionResult register()
        {
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        [Route("/Admin/Register")]
        [HttpPost]
        public async Task<IActionResult> register(User model)
        {
            if (ModelState.IsValid)
            {
                var checkUserByEmail = await _userManager.FindByEmailAsync(model.Email);

                if (checkUserByEmail != null)
                {
                    ModelState.AddModelError("Email", "Bu Email Zaten Kayıtlı ! Farklı Email Giriniz.");

                    ViewBag.Roles = _context.Roles.ToList();

                    return View();
                }

                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Şire Eşleşmiyor");
                    
                    ViewBag.Roles = _context.Roles.ToList();

                    return View();
                }

                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.SelectedRole);

                    return RedirectToAction("user", "User");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }

            return RedirectToAction("hiçbiri");
        }

        [Route("/Admin/Delete/{Id}")]
        public async Task<IActionResult> UserDelete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
           
            var result = await _userManager.DeleteAsync(user);
          
            return RedirectToAction("user", "User");
        }
    }
}
