using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository postRepository;

        public PostController(IPostRepository repo)
        {
            this.postRepository = repo;
        }

        public PartialViewResult TopPosts()
        {
            var topPosts = this.postRepository.Posts
                .OrderByDescending(p => p.Rating)
                .Take(GlobalConstants.HomePageTopPostsCount);

            return this.PartialView(topPosts);
        }

        public PartialViewResult LatestPosts()
        {
            var latestPosts = this.postRepository.Posts
                .OrderByDescending(p => p.Date)
                .Take(GlobalConstants.HomePageTopPostsCount);

            return this.PartialView("_TopPostsPartial",latestPosts);
        }
    }
}