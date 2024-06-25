using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookAuthorMappingCreateDto: ICreateDto<BookAuthorMapping, Guid>
{
    public Guid AuthorId { get; set; }
    public BookAuthorMapping GetEntity()
    {
        return new BookAuthorMapping()
        {
            AuthorId = AuthorId,
        };
    }
}