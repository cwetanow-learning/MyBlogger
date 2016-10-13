using BlogSystem.Domain.Concrete.Abstract;
using BlogSystem.Domain.Contracts;
using System.Collections.Generic;
using BlogSystem.Domain.Models;
using System.Data.Entity;
using BlogSystem.Domain.Contracts.Entities;

namespace BlogSystem.Domain.Concrete
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<IComment> Comments
        {
            get
            {
                return this.context.Comments
                    .Include(c => c.Author)
                    .Include(c => c.Post);
            }
        }

        public void DeleteComment(int commentId)
        {
            var commentToDelete = this.context.Comments.Find(commentId);

            if (commentToDelete != null)
            {
                commentToDelete.IsDeleted = true;
            }

            this.SaveChanges();
        }

        public void WriteComment(Comment comment, int postId, string authorId)
        {
            var post = this.GetPostById(postId);
            var author = this.GetUserById(authorId);

            comment.Post = post;
            comment.Author = author;

            this.context.Comments.Add(comment);
            post.Comments.Add(comment);

            this.SaveChanges();
        }
    }
}
