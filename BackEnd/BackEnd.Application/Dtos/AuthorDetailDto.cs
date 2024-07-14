using BackEnd.Application.Constant;
using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class AuthorDetailDto : IDetailDto<Author, Guid>, IFullAudited
{
    public string Name { get; set; }
    public string NickName { get; set; }
    
    public void FromEntity(Author entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        NickName = entity.NickName;
        CreationTime = entity.CreationTime;
        CreatorUserId = entity.CreatorUserId;
        IsDeleted = entity.IsDeleted;
    }

    public Guid Id { get; set; }
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
}