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
    }
}
