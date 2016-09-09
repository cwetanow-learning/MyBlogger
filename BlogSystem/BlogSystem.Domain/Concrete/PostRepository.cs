using BlogSystem.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Concrete.Abstract;
using BlogSystem.Domain.Utils;
using System.Data.Entity;

namespace BlogSystem.Domain.Concrete
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public IEnumerable<Post> Posts
        {
            get
            {
                return this.context.Posts
                    .Include(x => x.Comments)
                    .Include(x => x.Author);
            }
        }

        public void ChangeRating(int postId, int value)
        {
            var post = this.context.Posts.Find(postId);
            post.Rating += value;

            this.SaveChanges();
        }

        public Post DeletePost(Post post)
        {
            var postToDelete = this.Posts.FirstOrDefault(p => p.PostId == post.PostId);
            if (postToDelete != null)
            {
                postToDelete.IsDeleted = true;

                this.SaveChanges();
            }

            return postToDelete;
        }

        public void SavePost(Post post)
        {
            post.Author = this.GetUserById(post.Author.Id);

            if (post.PostId == GlobalConstants.IdOfEntityNotInDB)
            {
                this.context.Posts.Add(post);
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

                    this.context.Entry(postToEdit).State = System.Data.Entity.EntityState.Modified;
                    this.context.Entry(postToEdit).Reference(t => t.Author).Load();
                    this.context.Entry(postToEdit).Reference(t => t.Comments).Load();
                }
            }

            this.SaveChanges();
        }
    }
}
