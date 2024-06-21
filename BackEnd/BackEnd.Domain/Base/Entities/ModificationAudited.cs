namespace BackEnd.Domain.Base.Entities;

public class ModificationAudited : IModificationAudited
{
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
}