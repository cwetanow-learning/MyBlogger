using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers.Abstract;
using BlogSystem.Web.Models;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class CommentController : BaseController
    {
        private ICommentRepository repository;

        public CommentController(ICommentRepository repo)
        {
            this.repository = repo;
        }

        [HttpPost]
        public PartialViewResult CommentPost(CommentViewModel commentWithPostId)
        {
            var comment = new Comment
            {
                CommentText = commentWithPostId.Text,
                Date = DateHelper.GetCurrentTime()
            };

            var userId = this.GetCurrentUserId();

            this.repository.WriteComment(comment, commentWithPostId.PostId, userId);

            return this.PartialView("_RenderCommentsPartial", comment.Post.Comments);
        }
    }
}