using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Entity.Entities;

public class Author : FullAudited<Guid>
{
    public string Name { get; set; }
    public string NickName { get; set; }

    public ICollection<BookAuthorMapping> BookAuthorMappings { get; set; }
}