using Clean_Blog.Data;
using Clean_Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly CleanBlogContext _context;

        public PageController(CleanBlogContext context)
        {
            _context = context;
        }

        [Route("/admin/home")]
        public IActionResult Home()
        {
            var home = _context.Pages.FirstOrDefault(p => p.PageNumber == 1);

            if (home == null)
            {
                var newHome = new Page
                {
                    
                    Img = "",
                    BigTitle = "",
                    SmallTitle="",
                    Description = "",
                    PageNumber = 1,
                };

                _context.Pages.Add(newHome);
                _context.SaveChanges();

                return RedirectToAction("Home");

            }

            return View(home);
        }


        [Route("/admin/home")]
        [HttpPost]
        public IActionResult Home(Page page)
        {
           _context.Pages.Update(page);
           _context.SaveChanges();
            return RedirectToAction("home");
        }

        [Route("/admin/About")]
        public IActionResult About()
        {
          
            var about = _context.Pages.FirstOrDefault(p => p.PageNumber == 2);


            if (about == null)
            {
                var newAbout = new Page
                {
                    
                    Img = "",
                    BigTitle = "",
                    SmallTitle = "",
                    Description = "",
                    PageNumber = 2,
                };

                _context.Pages.Add(newAbout);
                _context.SaveChanges();

                return RedirectToAction("About");

            }

            return View(about);
        }

        [Route("/admin/About")]
        [HttpPost]
        public IActionResult About(Page page)
        {
            _context.Pages.Update(page);
            _context.SaveChanges();
            return RedirectToAction("About");
        }

        [Route("/admin/Populer")]
        public IActionResult Populer()
        {
            var populer = _context.Pages.FirstOrDefault(p => p.PageNumber == 3);


            if (populer == null)
            {
                var newPopuler = new Page
                {
                 
                    Img = "",
                    BigTitle = "",
                    SmallTitle = "",
                    Description = "",
                    PageNumber = 3,
                };

                _context.Pages.Add(newPopuler);
                _context.SaveChanges();

                return RedirectToAction("Populer");

            }

            return View(populer);
        }


        [Route("/admin/Populer")]
        [HttpPost]
        public IActionResult Populer(Page page)
        {
            _context.Pages.Update(page);
            _context.SaveChanges();
            return RedirectToAction("Populer");
        }

        [Route("/admin/Contact")]
        public IActionResult Contact()
        {
            var contact = _context.Pages.FirstOrDefault(p => p.PageNumber == 4);

            if (contact == null)
            {
                var newContact = new Page
                {

                    Img = "",
                    BigTitle = "",
                    SmallTitle = "",
                    Description = "",
                    PageNumber = 4,
                };

                _context.Pages.Add(newContact);
                _context.SaveChanges();

                return RedirectToAction("Contact");

            }


            return View(contact);
        }

        [Route("/admin/Contact")]
        [HttpPost]
        public IActionResult Contact(Page page)
        {
            _context.Pages.Update(page);
            _context.SaveChanges();
            return RedirectToAction("Contact");
        }


    }
}
