using BlogSystem.Domain.Contracts;

namespace BlogSystem.Domain.Models.Abstract
{
    public class DeletableEntity : IDeletable
    {
        public bool IsDeleted
        {
            get; set;
        }
    }
}
