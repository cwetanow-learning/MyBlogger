using BlogSystem.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Concrete.Abstract;
using BlogSystem.Domain.Utils;
using System.Data.Entity;
using BlogSystem.Domain.Contracts.Entities;

namespace BlogSystem.Domain.Concrete
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(IApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<IPost> Posts
        {
            get
            {
                return this.context.Posts
                    .Include(x => x.Comments)
                    .Include(x => x.Author);
            }
        }

        public int ChangeRating(int postId, int value)
        {
            var post = this.context.Posts.Find(postId);

            if (post.Rating == GlobalConstants.MinimumPostRating && MathHelper.IsNegative(value))
            {
                return post.Rating;
            }

            post.Rating += value;

            this.SaveChanges();

            return post.Rating;
        }

        public IEnumerable<IPost> GetUserPosts(string userId)
        {
            var userPosts = this.Posts
                .Where(x => x.Author.Id == userId && !x.IsDeleted);

            return userPosts;
        }

        public IPost GetPostById(int postId)
        {
            var post = this.Posts
                .FirstOrDefault(p => p.PostId == postId && !p.IsDeleted);

            return post;
        }

        public IPost DeletePost(int postId)
        {
            var postToDelete = this.Posts
                .FirstOrDefault(p => p.PostId == postId);

            if (postToDelete != null)
            {
                postToDelete.IsDeleted = true;

                foreach (var comment in postToDelete.Comments)
                {
                    comment.IsDeleted = true;
                }

                this.SaveChanges();
            }

            return postToDelete;
        }

        public void SavePost(Post post, string authorId)
        {
            post.Author = this.GetUserById(authorId);

            if (post.PostId == GlobalConstants.IdOfEntityNotInDB)
            {
                this.context.Posts.Add(post);
                post.Author.Posts.Add(post);
            }
            else
            {
                var postToEdit = this.context.Posts.Find(post.PostId);

                if (postToEdit != null)
                {
                    postToEdit.Title = post.Title;
                    postToEdit.Text = post.Text;
                    postToEdit.Subtitle = post.Subtitle;
                    postToEdit.Date = post.Date;
                }
            }

            this.SaveChanges();
        }
    }
}
