using Abp.Domain.Entities.Auditing;

namespace BackEnd.Entities;
public class WaitingList : FullAuditedEntity<Guid>
{
    public Guid MemberId { get; set; }
    public Guid BookId { get; set; }

    public Book Book { get; set; }
    public Member Member { get; set; }
}