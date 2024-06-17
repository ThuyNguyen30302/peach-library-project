using BackEnd.Base.Audit;
using BackEnd.Base.Dto;
using BackEnd.Entities;

namespace BackEnd.Dtos;

public class BookDetailDto : IDetailDto<Book, Guid>, IFullAudited<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; } 
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
    public void FromEntity(Book entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        Type = entity.Type;
        CreationTime = entity.CreationTime;
        CreatorUserId = entity.CreatorUserId;
        IsDeleted = entity.IsDeleted;
    }
    
    public bool IsTransient()
    {
        throw new NotImplementedException();
    }

}