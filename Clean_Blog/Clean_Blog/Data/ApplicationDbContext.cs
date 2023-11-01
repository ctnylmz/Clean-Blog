using Clean_Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Clean_Blog.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Header> Headers { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}
