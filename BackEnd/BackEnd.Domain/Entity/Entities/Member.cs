using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Ums.Entities;

namespace BackEnd.Domain.Entity.Entities;

public class Member : FullAudited<Guid>
{
    public string CardNumber { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string Status { get; set; }
    public DateTime DoB { get; set; }
    public string Address { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public ICollection<CheckOut> CheckOuts { get; set; }
    public ICollection<Hold> Holds { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<WaitingList> WaitingLists { get; set; }
}
