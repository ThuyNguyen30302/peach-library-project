using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Entity.Entities;

public class BookAuthorMapping
{
    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }

    public Author Author { get; set; }
    public Book Book { get; set; }
}
