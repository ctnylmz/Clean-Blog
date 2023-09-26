using CleanBlog.Data;
using CleanBlog.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace CleanBlog.Utilites
{
	public class DbInitializer : IDbInitializer
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
			_userManager = userManager;
			_roleManager = roleManager;
        }
        public void Initialize()
		{
			if (!_roleManager.RoleExistsAsync(Roles.Admin).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(Roles.Author)).GetAwaiter().GetResult();
				_userManager.CreateAsync(new ApplicationUser()
				{
					UserName = "admin@gmail.com",
					Email = "admin@gmail.com",
					FirstName = "Super",
					LastName = "Admin"
				}, "Admin@0011").Wait();

				var appUser = _context.ApplicationUsers.FirstOrDefault(x=>x.Email == "admin@gmail.com");
				if (appUser != null)
				{
						_userManager.AddToRoleAsync(appUser,Roles.Admin).GetAwaiter().GetResult();
				}

				
				var listOfPages = new List<Page>()
				{
				new Page()
				{
					Title = "About Us",
					Slug = "About"
				},

				new Page()
				{
					Title = "Contact Us",
					Slug = "contact"
				},
					new Page()
					{
					Title = "Privacy Policy",
					Slug = "privacy"
					},
				};
				_context.Pages.AddRange(listOfPages);
				_context.SaveChanges();
			}
		}
	}
}
