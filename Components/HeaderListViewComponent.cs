using Clean_Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Blog.Components
{
    public class HeaderListViewComponent:ViewComponent
    {
        private readonly CleanBlogContext _context;

        public HeaderListViewComponent(CleanBlogContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var header = _context.Headers.Find(1);

            return View(header);
        }
    }
}
