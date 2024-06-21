using BackEnd.Application.Constant;
using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Dtos;

public class MemberDetailDto: IDetailDto<Member, Guid>, IFullAudited
{
    public void FromEntity(Member entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        CardNumber = entity.CardNumber;
        Email = entity.Email;
        Age = entity.Age;
        Address = entity.Address;
        UserName = entity.UserName;
        Password = entity.Password;
        Status = entity.Status;
        CreationTime = entity.CreationTime?.AddHours(TimeZoneConstant.TimeZoneSea);
        CreatorUserId = entity.CreatorUserId;
        IsDeleted = entity.IsDeleted;
    }

    public Guid Id { get; set; }
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
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
}