using BackEnd.Base.Audit;

namespace BackEnd.Entities;

public class BookCopy : FullAudited<Guid>
{
    public DateTime YearPublisher { get; set; }
    public decimal Price { get; set; }
    public Guid BookId { get; set; }
    public Guid PublisherId { get; set; }
    public bool Active { get; set; }
    
    public Book Book { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<CheckOut> CheckOuts { get; set; }
    public ICollection<Hold> Holds { get; set; }
}