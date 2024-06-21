using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entities;

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
            Age = Age,
            UserName = UserName,
            Password = Password,
            Status = Status,
            CreationTime = CreationTime,
            CreatorUserId = CreatorUserId,
        };
    }
    public string CardNumber { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
}