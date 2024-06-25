using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Entity.Entities;

public class Hold : FullAudited<Guid>
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid MemberId { get; set; }
    public Guid BookCopyId { get; set; }

    public BookCopy BookCopy { get; set; }
    public Member Member { get; set; }
}
