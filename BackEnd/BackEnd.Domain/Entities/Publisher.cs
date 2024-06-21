using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Entities;

public class Publisher : FullAudited<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }

    public ICollection<BookCopy> BookCopies { get; set; }
}
