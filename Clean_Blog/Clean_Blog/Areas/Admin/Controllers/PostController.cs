using Clean_Blog.Data;
using Clean_Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }




        [Route("/Admin/Post/Create")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [Route("/Admin/Post/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Enter model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                model.UserId = user.Id;
              
                _context.Enters.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");

            }

            return View(model);
        }

        [Route("/Admin/Post")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var post = _context.Enters.Where(p => p.UserId == user.Id).ToList();
            
            return View(post);
        }

    }
}
