using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookAuthorMappingUpdateDto
{
    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }
    public BookAuthorMapping GetEntity()
    {
        return new BookAuthorMapping()
        {
            AuthorId = AuthorId,
            BookId = BookId,
        };
    }
}