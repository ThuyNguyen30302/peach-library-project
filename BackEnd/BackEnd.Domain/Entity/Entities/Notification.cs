using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Entities;

public class Notification: FullAudited<Guid>
{
    public string Type { get; set; }
    public DateTime SendAt { get; set; }
    public Guid MemberId { get; set; }

    public Member Member { get; set; }
}
