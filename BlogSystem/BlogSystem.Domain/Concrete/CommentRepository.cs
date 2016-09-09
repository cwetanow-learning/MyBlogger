using BlogSystem.Domain.Concrete.Abstract;
using BlogSystem.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Domain.Models;
using System.Data.Entity;
using BlogSystem.Domain.Contracts.Entities;

namespace BlogSystem.Domain.Concrete
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public IEnumerable<IComment> Comments
        {
            get
            {
                return this.context.Comments
                    .Include(c => c.Author)
                    .Include(c => c.Post);
            }
        }
    }
}
