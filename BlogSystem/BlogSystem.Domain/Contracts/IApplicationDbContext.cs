using BlogSystem.Domain.Models;
using System.Data.Entity;

namespace BlogSystem.Domain.Contracts
{
    public interface IApplicationDbContext
    {
        IDbSet<Post> Posts { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        void Save();
    }
}
