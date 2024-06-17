namespace BackEnd.Base.Audit;

public interface IModificationAudited
{
    DateTime? LastModificationTime { get; set; }
    Guid? LastModifierUserId { get; set; }
}