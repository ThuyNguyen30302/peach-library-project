using BackEnd.Application.Constant;
using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookDetailDto : IDetailDto<Book, Guid>, IFullAudited
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; } 
    public string Authors { get; set; } 
    public string Types { get; set; } 
    public DateTime? CreationTime { get; set; }
    public int? Amount { get; set; }
    public Guid? CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public ICollection<BookAuthorMappingDetailDto> BookAuthorMappings { get; set; }
    public bool IsDeleted { get; set; }
    public void FromEntity(Book entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        Type = entity.Type;
        CreationTime = entity.CreationTime?.AddHours(TimeZoneConstant.TimeZoneSea);
        CreatorUserId = entity.CreatorUserId;
        IsDeleted = entity.IsDeleted;
        Amount = entity.BookCopies?.Count;
        BookAuthorMappings = entity.BookAuthorMappings.Select(x =>
        {
            var res = new BookAuthorMappingDetailDto();
            res.FromEntity(x);
            return res;
        }).ToList();
    }
}