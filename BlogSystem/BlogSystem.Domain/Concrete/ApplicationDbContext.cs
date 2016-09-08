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
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
