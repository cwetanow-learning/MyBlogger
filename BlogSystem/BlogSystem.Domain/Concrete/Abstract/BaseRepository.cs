using BlogSystem.Domain.Contracts;

namespace BlogSystem.Domain.Concrete.Abstract
{
    public abstract class BaseRepository
    {
        protected IApplicationDbContext context = new ApplicationDbContext();
    }
}
