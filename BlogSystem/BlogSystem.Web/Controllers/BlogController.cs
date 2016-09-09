﻿using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private IPostRepository repository;
        private ApplicationUser currentUser;
        private ApplicationUserManager userManager;

        public BlogController(IPostRepository repo)
        {
            this.repository = repo;
        }

        public ApplicationUser CurrentUser
        {
            get
            {
                return this.currentUser ?? this.UserManager.FindById(this.GetCurrentUserId());
            }
            private set
            {
                this.currentUser = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                this.userManager = value;
            }
        }

        public ViewResult Index()
        {
            var id = this.CurrentUser.Id;
            var posts = this.repository.Posts;
            var o = posts.Where(p => p.Author.Id == id);
            // var posts = this.repository.Posts.Where(p => p.Author.Id == this.CurrentUser.Id);
            return this.View(o);
        }

        public ViewResult Edit(int postId)
        {
            var post = this.repository.Posts.FirstOrDefault(p => p.PostId == postId);

            return this.View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Date = DateHelper.GetCurrentTime();
                var authorId = this.CurrentUser.Id;
                post.Author = new ApplicationUser { Id = authorId };

                this.repository.SavePost(post);
                this.TempData["message"] = $"{post.Text} has been saved !";

                return RedirectToAction("Index");
            }
            else
            {
                return this.View(post);
            }
        }

        public ViewResult Create()
        {
            return this.View("Edit", new Post());
        }

        private string GetCurrentUserId()
        {
            return System.Threading.Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}