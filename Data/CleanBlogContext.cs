using Clean_Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Clean_Blog.Data
{
    public class CleanBlogContext : IdentityDbContext
    {

        public CleanBlogContext(DbContextOptions<CleanBlogContext> options) : base(options)
        {

        }

        public DbSet<Header> Headers { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Enter> Enters { get; set; }
    }
}
