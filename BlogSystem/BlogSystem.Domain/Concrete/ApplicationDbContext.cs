using System;
using System.Data.Entity;
using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogSystem.Domain.Concrete
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Comment> Comments
        {
            get; set;
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public IDbSet<Post> Posts
        {
            get; set;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
