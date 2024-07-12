using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class MemberCreateDto: ICreateDto<Member, Guid>, ICreationAudited
{
    public Member GetEntity()
    {
        return new Member()
        {
            Name = Name,
            CardNumber = CardNumber,
            Email = Email,
            Address = Address,
            DoB = DoB.Date,
            PhoneNumber = PhoneNumber,
            Status = Status,
            CreationTime = DateTime.Now,
            CreatorUserId = CreatorUserId,
            UserId = UserId,
        };
    }
    public string CardNumber { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }
    public DateTime DoB { get; set; }
    public string Address { get; set; }
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
    public Guid UserId { get; set; }
}