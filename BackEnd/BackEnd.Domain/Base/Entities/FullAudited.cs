namespace BackEnd.Domain.Base.Entities;

public class FullAudited<TKey> : Entity<TKey>, IFullAudited
{
    public FullAudited()
    {
        CreationTime = DateTime.Now.AddHours(7);
    }

    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
}