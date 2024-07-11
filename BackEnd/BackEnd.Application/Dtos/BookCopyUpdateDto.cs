using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookCopyUpdateDto: IUpdateDto<BookCopy, Guid>, IModificationAudited
{
    public Guid Id { get; set; }
    public DateTime YearPublisher { get; set; }
    public decimal Price { get; set; }
    public Guid BookId { get; set; }
    public Guid PublisherId { get; set; }
    public bool Active { get; set; }
    public BookCopy GetEntity(BookCopy entity)
    {
        entity.Id = Id;
        entity.YearPublisher = entity.YearPublisher;
        entity.Price = entity.Price;
        entity.Active = entity.Active;
        entity.BookId = entity.BookId;
        entity.PublisherId = entity.PublisherId;
        entity.LastModificationTime = DateTime.Now;
        entity.LastModifierUserId = LastModifierUserId;
        return entity;
    }

    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
}