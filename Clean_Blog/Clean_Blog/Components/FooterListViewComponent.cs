
using Clean_Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clean_Blog.Components
{
    public class FooterListViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public FooterListViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footer = _context.Footers.Find(1);
            return View(footer);
        }
    }
}
