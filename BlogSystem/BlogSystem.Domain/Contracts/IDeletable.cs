namespace BlogSystem.Domain.Contracts
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
