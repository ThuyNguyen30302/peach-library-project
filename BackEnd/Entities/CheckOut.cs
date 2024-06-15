using Abp.Domain.Entities.Auditing;

namespace BackEnd.Entities;

public class CheckOut : FullAuditedEntity<Guid>
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsReturned { get; set; }
    public Guid MemberId { get; set; }
    public Guid BookCopyId { get; set; }

    public BookCopy BookCopy { get; set; }
    public Member Member { get; set; }
}
