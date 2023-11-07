using Clean_Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clean_Blog.Components
{
    public class HomeHeaderListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public HomeHeaderListViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var home = _context.Pages.Find(1);
            return View(home);
        }
    }
}
