using BlogSystem.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Concrete.Abstract;

namespace BlogSystem.Domain.Concrete
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public IEnumerable<Post> Posts
        {
            get
            {
                return this.context.Posts;
            }
        }

        public void SavePost(Post post)
        {
            if (post.PostId == 0)
            {
                this.context.Posts.Add(post);
            }
            else
            {
                var newPost = this.context.Posts.Find(post.PostId);
                if (newPost != null)
                {
                    newPost.Title = post.Title;
                    newPost.Text = post.Text;
                    newPost.Subtitle = post.Subtitle;
                    newPost.Date = post.Date;
                }
            }

            this.SaveChanges();
        }
    }
}
