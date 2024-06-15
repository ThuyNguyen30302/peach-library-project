using Abp.Domain.Entities;

namespace BackEnd.Entities;

public class BookAuthorMapping : Entity<Guid>
{
    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }

    public Author Author { get; set; }
    public Book Book { get; set; }
}
