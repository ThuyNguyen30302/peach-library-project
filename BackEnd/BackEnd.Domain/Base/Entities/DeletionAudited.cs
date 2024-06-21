namespace BackEnd.Domain.Base.Entities;

public class DeletionAudited : IDeletionAudited
{
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
}