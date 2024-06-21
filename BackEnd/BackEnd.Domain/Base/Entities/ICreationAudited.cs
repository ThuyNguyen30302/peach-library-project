namespace BackEnd.Domain.Base.Entities;

public interface ICreationAudited
{
    DateTime? CreationTime { get; set; }
    Guid? CreatorUserId { get; set; }
}