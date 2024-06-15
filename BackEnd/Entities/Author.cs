using Abp.Domain.Entities.Auditing;

namespace BackEnd.Entities;

public class Author : FullAuditedEntity<Guid>
{
    public string Name { get; set; }
    public string NickName { get; set; }

    public ICollection<BookAuthorMapping> BookAuthorMappings { get; set; }
}