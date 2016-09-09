using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Contracts
{
    public interface IPostRepository
    {
        IEnumerable<Post> Posts { get; }

        void SavePost(Post post);

        Post DeletePost(Post post);
    }
}
