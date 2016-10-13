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
        private IDateProvider dateProvider;

        public CommentController(ICommentRepository repo, IDateProvider dateProvider)
        {
            this.repository = repo;
            this.dateProvider = dateProvider;
        }

        [HttpPost]
        public PartialViewResult CommentPost(CommentViewModel commentWithPostId)
        {
            var comment = new Comment
            {
                CommentText = commentWithPostId.Text,
                Date = this.dateProvider.GetCurrentDate()
            };

            var userId = this.GetCurrentUserId();

            this.repository.WriteComment(comment, commentWithPostId.PostId, userId);

            var comments = this.repository.Comments
                .Where(c => !c.IsDeleted)
                .Where(c => c.Post.PostId == commentWithPostId.PostId)
                .OrderByDescending(x => x.Date)
                .ToList(); ;

            return this.PartialView("RenderComments", comments);
        }

        public PartialViewResult RenderComments(IEnumerable<IComment> comments, int page = 1)
        {
            var commentIds = comments.Select(x => x.CommentId);

            var result = this.repository.Comments
                .Where(c => !c.IsDeleted)
                .Where(c => commentIds.Contains(c.CommentId))
                .OrderByDescending(x => x.Date)
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