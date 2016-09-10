using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;

namespace BlogSystem.Domain.Concrete.Abstract
{
    public abstract class BaseRepository
    {
        protected ApplicationDbContext context = new ApplicationDbContext();

        protected void SaveChanges()
        {
            this.context.SaveChanges();
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
