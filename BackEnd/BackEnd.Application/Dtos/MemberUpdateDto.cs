using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class MemberUpdateDto: IUpdateDto<Member, Guid>, IModificationAudited
{
    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public Member GetEntity(Member entity)
    {
        entity.Id = Id;
        entity.Name = !string.IsNullOrEmpty(Name) ? Name : entity.Name;
        entity.CardNumber = !string.IsNullOrEmpty(CardNumber) ? CardNumber : entity.CardNumber;
        entity.Email = !string.IsNullOrEmpty(Email) ? Email : entity.Email;
        entity.Address = !string.IsNullOrEmpty(Address) ? Address : entity.Address;
        entity.Age = Age;
        entity.PhoneNumber = PhoneNumber;
        entity.UserName = !string.IsNullOrEmpty(UserName) ? UserName : entity.UserName;
        entity.Status = !string.IsNullOrEmpty(Status) ? Status : entity.Status;
        entity.LastModificationTime = DateTime.Now;
        entity.LastModifierUserId = LastModifierUserId;
        entity.UserId = UserId;
        return entity;
    }

    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public Guid UserId { get; set; }
}