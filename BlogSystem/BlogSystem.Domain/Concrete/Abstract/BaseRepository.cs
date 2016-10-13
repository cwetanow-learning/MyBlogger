using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;

namespace BlogSystem.Domain.Concrete.Abstract
{
    public abstract class BaseRepository
    {
        protected IApplicationDbContext context;

        protected BaseRepository(IApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        protected void SaveChanges()
        {
            this.context.Save();
        }

        protected ApplicationUser GetUserById(string id)
        {
            var result = this.context.Users.Find(id);

            return result;
        }

        protected Post GetPostById(int id)
        {
            var result = this.context.Posts.Find(id);

            return result;
        }
    }
}
