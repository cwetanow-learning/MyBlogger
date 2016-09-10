using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers.Abstract;
using BlogSystem.Web.Models;
using System.Collections.Generic;
using System.Linq;
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

            return this.PartialView("RenderComments", comment.Post.Comments);
        }

        public PartialViewResult RenderComments(IEnumerable<IComment> comments)
        {
            var result = comments.OrderByDescending(x => x.Date)
                .Where(c => !c.IsDeleted)
                .ToList();

            return this.PartialView(result);
        }

        public ActionResult Delete(int commentId, int postId)
        {
            this.repository.DeleteComment(commentId);

            return this.RedirectToAction("PostView", new { controller = "Post", postId = postId });
        }
    }
}