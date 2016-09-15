using BlogSystem.Domain.Models;
using System.Collections.Generic;

namespace BlogSystem.Domain.Contracts
{
    public interface IApplicationUser
    {
        string Name { get; set; }

        ICollection<Post> Posts { get; }

        ICollection<Comment> Comments { get; }
    }
}
