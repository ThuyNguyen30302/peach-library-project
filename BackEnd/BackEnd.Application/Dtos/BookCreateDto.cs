using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookCreateDto : ICreateDto<Book, Guid>, ICreationAudited
{
    public string Title { get; set; }
    public string Type { get; set; }
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
    public bool Active { get; set; }
    public ICollection<BookAuthorMappingCreateDto> BookAuthorMappings { get; set; }
    public Book GetEntity()
    {
        return new Book()
        {
            Title = Title,
            Type = Type,
            CreationTime = CreationTime,
            CreatorUserId = CreatorUserId,
            Active = true,
            // BookAuthorMappings = BookAuthorMappings.Select(x => new BookAuthorMapping
            // {
            //     AuthorId = x.AuthorId,
            // }).ToList()
        };
    }
}