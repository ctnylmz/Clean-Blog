using Clean_Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly CleanBlogContext _context;

        public HomeController(CleanBlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var posts = _context.Enters.ToList();

            foreach (var post in posts)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == post.UserId);

                if (user != null)
                {
                    post.User = user;
                }
            }

            posts.Reverse();

         

            return View(posts);
        }



        [Route("Post/{Id}")]
        public IActionResult Post(int Id)
        {
            var post = _context.Enters.FirstOrDefault(p => p.Id == Id);

            var user = _context.Users.FirstOrDefault(u => u.Id == post.UserId);

            if (user != null)
            {
                post.User = user;
            }

            return View(post);
        }



    }
}
