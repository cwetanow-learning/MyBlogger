using BlogSystem.Domain.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public ApplicationUser() : base()
        {
            this.Comments = new HashSet<Comment>();
            this.Posts = new HashSet<Post>();
        }

        public virtual ICollection<Comment> Comments
        {
            get;
        }

        public string Name
        {
            get; set;
        }

        public virtual ICollection<Post> Posts
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
