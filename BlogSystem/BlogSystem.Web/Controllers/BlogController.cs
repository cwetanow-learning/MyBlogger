using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers.Abstract;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    [Authorize]
    public class BlogController : BaseController
    {
        private IPostRepository repository;

        public BlogController(IPostRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Index(int page = 1)
        {
            var posts = this.repository.Posts
                .Where(p => p.Author.Id == this.CurrentUser.Id && !p.IsDeleted)
                .ToPagedList(page, GlobalConstants.ListPostCount);

            return this.View(posts);
        }

        public ViewResult Edit(int postId)
        {
            var post = this.repository.Posts
                .FirstOrDefault(p => p.PostId == postId && !p.IsDeleted);

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

        public ActionResult Delete(int postId)
        {
            this.repository.DeletePost(postId);

            return this.RedirectToAction("Index", "Home");
        }
    }
}