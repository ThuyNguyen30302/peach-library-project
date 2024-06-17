namespace BackEnd.Base.Audit;

public class DeletionAudited : IDeletionAudited
{
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
}