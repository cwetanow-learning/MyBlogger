using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Web.Models;
using PagedList;
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
            var topPosts = this.postRepository.GetTopPosts()
                .ToList();

            return this.AllPosts(topPosts, count, page);
        }

        public PartialViewResult LatestPosts(int count, int page = 1)
        {
            var latestPosts = this.postRepository.GetLatestPosts()
                .ToList();

            return this.AllPosts(latestPosts, count, page);
        }

        public PartialViewResult AllPosts(IEnumerable<IPost> posts, int count, int page = 1)
        {
            if (posts == null)
            {
                posts = TempData["posts"] as IEnumerable<IPost>;
            }

            posts = posts.ToPagedList(page, count);

            return this.PartialView("_TopPostsPartial", posts);
        }

        public ViewResult PostView(int postId)
        {
            var post = this.postRepository.GetPostById(postId);

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