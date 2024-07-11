using BackEnd.Application.Constant;
using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookCopyDetailDto: IDetailDto<BookCopy, Guid>, IFullAudited
{
    public Guid Id { get; set; }
    public DateTime YearPublisher { get; set; }
    public decimal Price { get; set; }
    public Guid BookId { get; set; }
    public Guid PublisherId { get; set; }
    public bool Active { get; set; }
    
    public Book Book { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<CheckOut> CheckOuts { get; set; }
    public ICollection<Hold> Holds { get; set; }
    
    public void FromEntity(BookCopy entity)
    {
        Id = entity.Id;
        YearPublisher = entity.YearPublisher;
        Price = entity.Price;
        BookId = entity.BookId;
        PublisherId = entity.PublisherId;
        Active = entity.Active;
        CreationTime = entity.CreationTime?.AddHours(TimeZoneConstant.TimeZoneSea);
        CreatorUserId = entity.CreatorUserId;
        IsDeleted = entity.IsDeleted;
    }

    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
}