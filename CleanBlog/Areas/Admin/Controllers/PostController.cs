﻿using AspNetCoreHero.ToastNotification.Abstractions;
using CleanBlog.Data;
using CleanBlog.Models;
using CleanBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        public INotyfService _notification { get; }


        public PostController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, INotyfService notyfcation)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _notification = notyfcation;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePostVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostVM vm)
        {
            if (!ModelState.IsValid) { return View(vm); }

            //get logged in user id
            var loggedInUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);

            var post = new Post();

            post.Title = vm.Title;
            post.Description = vm.Description;
            post.ShortDescription = vm.ShortDescription;
            post.ApplicationUserId = loggedInUser!.Id;

            if (post.Title != null)
            {
                string slug = vm.Title!.Trim();
                slug = slug.Replace(" ", "-");
                post.Slug = slug + "-" + Guid.NewGuid();
            }

            if (vm.Thumbnail != null)
            {
                post.ThumbnailUrl = UploadImage(vm.Thumbnail);
            }

            await _context.Posts!.AddAsync(post);
            await _context.SaveChangesAsync();
            _notification.Success("Post Created Successfully");
            return RedirectToAction("Index");
        }

        private string UploadImage(IFormFile file)
        {
            string uniqueFileName = "";
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "thumbnails");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(folderPath, uniqueFileName);
            using (FileStream fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
            }
            return uniqueFileName;
        }

    }
}
