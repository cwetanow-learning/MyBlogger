using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
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
            var userId = this.User.Identity.GetUserId();
            this.posts = this.repository.Posts.Where(p => p.Author.Id == userId);
        }
    }
}