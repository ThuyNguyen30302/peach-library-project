namespace BackEnd.Domain.Base.Entities;

public interface IModificationAudited
{
    DateTime? LastModificationTime { get; set; }
    Guid? LastModifierUserId { get; set; }
}