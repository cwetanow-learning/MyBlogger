using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Web.Controllers.Abstract;
using BlogSystem.Web.Models;
using Microsoft.AspNet.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private IPostRepository postRepository;
        private ICommentRepository commentRepository;

        public ProfileController(IPostRepository postRepo, ICommentRepository commentRepo)
        {
            this.postRepository = postRepo;
            this.commentRepository = commentRepo;
        }

        public ActionResult Index(string userId)
        {
            var user = this.UserManager.FindById(userId);
            var comments = this.GetUserComments(userId);
            var posts = this.GetUserPosts(userId);

            var model = new ProfileViewModel { User = user, Comments = comments, Posts = posts };

            return View(model);
        }

        private IEnumerable<IPost> GetUserPosts(string userId)
        {
            var result = this.postRepository.Posts
                .Where(p => p.Author.Id == userId);

            return result;
        }

        private IEnumerable<IComment> GetUserComments(string userId)
        {
            var result = this.commentRepository.Comments
               .Where(p => p.Author.Id == userId);

            return result;
        }
    }
}