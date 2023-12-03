
using Clean_Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clean_Blog.Components
{
    public class FooterListViewComponent:ViewComponent
    {
        private readonly CleanBlogContext _context;

        public FooterListViewComponent(CleanBlogContext context)
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
