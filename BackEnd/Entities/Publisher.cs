using Abp.Domain.Entities.Auditing;

namespace BackEnd.Entities;

public class Publisher : FullAuditedEntity<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }

    public ICollection<BookCopy> BookCopies { get; set; }
}
