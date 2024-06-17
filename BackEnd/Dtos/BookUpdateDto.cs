using BackEnd.Base.Audit;
using BackEnd.Base.Dto;
using BackEnd.Entities;

namespace BackEnd.Dtos;

public class BookUpdateDto : IUpdateDto<Book, Guid>, IModificationAudited
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public Book GetEntity(Book oldEntity)
    {        
        oldEntity.Id = Id;
        oldEntity.Title = string.IsNullOrEmpty(Title) ? Title : oldEntity.Title;
        oldEntity.Type = string.IsNullOrEmpty(Type) ? Type : oldEntity.Type;
        oldEntity.LastModificationTime = LastModificationTime;
        oldEntity.LastModifierUserId = LastModifierUserId;
        return oldEntity;
    }
}