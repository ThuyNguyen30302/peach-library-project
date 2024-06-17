namespace BackEnd.Base.Audit;

public class FullAudited<TKey> : IFullAudited<TKey>
{
    public bool IsTransient()
    {
        throw new NotImplementedException();
    }

    public TKey Id { get; set; }
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
}