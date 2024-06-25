using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookAuthorMappingDetailDto 
    // : IDetailDto<BookAuthorMapping, Guid>
{
    // public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }

    public Author Author { get; set; }
    public Book Book { get; set; }
    public void FromEntity(BookAuthorMapping entity)
    {
        // Id = entity.Id;
        AuthorId = entity.AuthorId;
        BookId = entity.BookId;
        Author = Author;
        Book = Book;
    }
}