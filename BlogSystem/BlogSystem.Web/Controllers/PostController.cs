using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Models;
using System.Collections.Generic;
using System.Linq;
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

        public PartialViewResult TopPosts(int count, int page = 1)
        {
            var topPosts = this.postRepository.Posts
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.Comments.Count)
                .ThenByDescending(p => p.Date)
                .Take(count);

            return this.AllPosts(topPosts);
        }

        public PartialViewResult LatestPosts(int count, int page = 1)
        {
            var latestPosts = this.postRepository.Posts
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Date)
                .Skip((page - 1) * GlobalConstants.ListPostCount)
                .Take(count);

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

        public PartialViewResult Rating(int id, int rating)
        {
            var postRating = this.postRepository.ChangeRating(id, rating);

            return this.PartialView(postRating);
        }

        public ViewResult List(bool byDate = false, bool byRating = false, int page = 1)
        {
            var model = new ListPostViewModel { ByDate = byDate, ByRating = byRating, Page = page };

            return this.View(model);
        }
    }
}