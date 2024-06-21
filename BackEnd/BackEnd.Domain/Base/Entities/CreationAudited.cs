namespace BackEnd.Domain.Base.Entities;

public class CreationAudited : ICreationAudited
{
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
}