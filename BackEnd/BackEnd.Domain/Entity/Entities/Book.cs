using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Entities;

public class Book : FullAudited<Guid>
{
    public string Title { get; set; }
    public string Type { get; set; }
    public bool Active { get; set; }

    public ICollection<BookAuthorMapping> BookAuthorMappings { get; set; }
    public ICollection<BookCopy> BookCopies { get; set; }
    public ICollection<WaitingList> WaitingLists { get; set; }
}