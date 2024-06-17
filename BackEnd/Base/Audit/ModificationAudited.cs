namespace BackEnd.Base.Audit;

public class ModificationAudited : IModificationAudited
{
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
}