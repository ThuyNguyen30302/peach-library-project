using Abp.Domain.Entities.Auditing;

namespace BackEnd.Entities;

public class Notification: FullAuditedEntity<Guid>
{
    public string Type { get; set; }
    public DateTime SendAt { get; set; }
    public Guid MemberId { get; set; }

    public Member Member { get; set; }
}
