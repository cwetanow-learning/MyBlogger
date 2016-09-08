using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;
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

        public BlogController(IPostRepository repo)
        {
            this.repository = repo;
            this.FilterPosts();
        }

        public ViewResult Index()
        {
            return this.View(this.posts);
        }

        private void FilterPosts()
        {
            var user = System.Threading.Thread.CurrentPrincipal.Identity.GetUserId();
            this.posts = this.repository.Posts.Where(p => p.Author.Id == user);
        }
    }
}