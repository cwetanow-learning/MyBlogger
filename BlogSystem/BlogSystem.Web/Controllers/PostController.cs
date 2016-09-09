using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
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
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.Date)
                .Take(GlobalConstants.HomePageTopPostsCount);

            return this.AllPosts(topPosts);
        }

        public PartialViewResult LatestPosts()
        {
            var latestPosts = this.postRepository.Posts
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Date)
                .Take(GlobalConstants.HomePageTopPostsCount);

            return this.AllPosts(latestPosts);
        }

        public PartialViewResult AllPosts(IEnumerable<IPost> posts)
        {
            return this.PartialView("_TopPostsPartial", posts);
        }

        public ViewResult PostView(int postId)
        {
            var post = this.postRepository.Posts.FirstOrDefault(p => p.PostId == postId);

            return this.View(post);
        }
    }
}