using BackEnd.Base.Audit;

namespace BackEnd.Entities;
public class WaitingList : FullAudited<Guid>
{
    public Guid MemberId { get; set; }
    public Guid BookId { get; set; }

    public Book Book { get; set; }
    public Member Member { get; set; }
}