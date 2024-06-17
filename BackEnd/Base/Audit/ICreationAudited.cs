namespace BackEnd.Base.Audit;

public interface ICreationAudited
{
    DateTime? CreationTime { get; set; }
    Guid? CreatorUserId { get; set; }
}