using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookCopyCreateDto: ICreateDto<BookCopy, Guid>, ICreationAudited
{
    public DateTime YearPublisher { get; set; }
    public decimal Price { get; set; }
    public Guid BookId { get; set; }
    public Guid PublisherId { get; set; }
    public bool Active { get; set; }
    public BookCopy GetEntity()
    {
        return new BookCopy()
        {
            YearPublisher = YearPublisher,
            Price = Price,
            BookId = BookId,
            PublisherId = PublisherId,
            Active = true,
            CreationTime = DateTime.Now,
            CreatorUserId = CreatorUserId,
        };
    }

    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
}