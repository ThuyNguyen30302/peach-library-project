using Abp.Domain.Repositories;
using BackEnd.Base.Audit;

namespace BackEnd.Entities;

public class Publisher : FullAudited<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }

    public ICollection<BookCopy> BookCopies { get; set; }
}
