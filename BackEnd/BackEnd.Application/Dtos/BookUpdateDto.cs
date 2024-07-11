using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookUpdateDto : IUpdateDto<Book, Guid>, IModificationAudited
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public ICollection<BookAuthorMappingUpdateDto> BookAuthorMappings { get; set; }

    public Book GetEntity(Book oldEntity)
    {        
        oldEntity.Id = Id;
        oldEntity.Title = string.IsNullOrEmpty(Title) ? Title : oldEntity.Title;
        oldEntity.Type = string.IsNullOrEmpty(Type) ? Type : oldEntity.Type;
        oldEntity.LastModificationTime = DateTime.Now;
        oldEntity.LastModifierUserId = LastModifierUserId;
        oldEntity.BookAuthorMappings = BookAuthorMappings.Select(x => new BookAuthorMapping
        {
            BookId = Id,
            AuthorId = x.AuthorId,
        }).ToList();
        return oldEntity;
    }
}