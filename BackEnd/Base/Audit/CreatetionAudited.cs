namespace BackEnd.Base.Audit;

public class CreatetionAudited : ICreationAudited
{
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
}