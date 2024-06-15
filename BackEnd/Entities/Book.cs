using Abp.Domain.Entities.Auditing;

namespace BackEnd.Entities;

public class Book : FullAuditedEntity<Guid>
{
    public string Title { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }

    public ICollection<BookAuthorMapping> BookAuthorMappings { get; set; }
    public ICollection<BookCopy> BookCopies { get; set; }
    public ICollection<WaitingList> WaitingLists { get; set; }
}