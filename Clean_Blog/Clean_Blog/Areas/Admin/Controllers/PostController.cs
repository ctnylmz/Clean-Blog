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


        [Route("/Admin/GetAllPost")]
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var post =  _context.Enters.ToList();

            foreach (var item in post)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == item.UserId);

                if (user != null)
                {
                    item.User = user;
                }
            }


            post.Reverse();

            return View(post);
        }


        [Route("/Admin/PostDelete/{Id}")]
        [HttpGet]
        public async Task<IActionResult> PostDelete(int id)
        {
  

            var post = _context.Enters.Find(id);

            _context.Remove(post);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [Route("/Admin/PostAllDelete/{Id}")]
        [HttpGet]
        public async Task<IActionResult> PostAllDelete(int id)
        {


            var post = _context.Enters.Find(id);

            _context.Remove(post);

            _context.SaveChanges();

            return RedirectToAction("GetAllPost");
        }

    }
}
