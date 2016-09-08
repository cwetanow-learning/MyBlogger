using BlogSystem.Domain.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Domain.Contracts.Entities;

namespace BlogSystem.Domain.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public ApplicationUser() : base()
        {
            this.Comments = new HashSet<Comment>();
            this.Posts = new HashSet<Post>();
        }

        public virtual IEnumerable<Comment> Comments
        {
            get;
        }

        public string Name
        {
            get; set;
        }

        public virtual IEnumerable<Post> Posts
        {
            get;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
