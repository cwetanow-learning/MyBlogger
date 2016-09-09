using BlogSystem.Domain.Contracts;

namespace BlogSystem.Domain.Concrete.Abstract
{
    public abstract class BaseRepository
    {
        protected ApplicationDbContext context = new ApplicationDbContext();

        protected void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
