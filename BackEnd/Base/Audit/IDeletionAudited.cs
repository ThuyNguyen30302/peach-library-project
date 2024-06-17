namespace BackEnd.Base.Audit;

public interface IDeletionAudited
{
    DateTime? DeletionTime { get; set; }
    Guid? DeleterUserId { get; set; }
    bool IsDeleted { get; set; }
}