using BlogSystem.Domain.Contracts;
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
        private IEnumerable<Post> posts;
        private ApplicationUser currentUser;

        public BlogController(IPostRepository repo)
        {
            this.repository = repo;

            this.currentUser = this.GetUser();
            this.FilterPosts();
        }

        public ViewResult Index()
        {
            return this.View(this.posts);
        }

        public ViewResult Edit(int postId)
        {
            var post = this.posts.FirstOrDefault(p => p.PostId == postId);

            return this.View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Date = DateHelper.GetCurrentTime();
                post.Author = this.currentUser;

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

        private ApplicationUser GetUser()
        {
            var manager = this.HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            var userId = System.Threading.Thread.CurrentPrincipal.Identity.GetUserId();

            var user = manager.FindById(userId);

            return user;
        }

        private void FilterPosts()
        {
            this.posts = this.repository.Posts.Where(p => p.Author.Id == this.currentUser.Id);
        }
    }
}