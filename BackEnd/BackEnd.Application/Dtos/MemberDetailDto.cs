using BackEnd.Application.Constant;
using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class MemberDetailDto: IDetailDto<Member, Guid>, IFullAudited
{
    public void FromEntity(Member entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        CardNumber = entity.CardNumber;
        Email = entity.Email;
        DoB = entity.DoB;
        Address = entity.Address;
        PhoneNumber = entity.PhoneNumber;
        UserName = entity.UserName;
        if (entity.User != null)
        {
            Password = entity.User.PasswordHash;
        }
        Status = entity.Status;
        CreationTime = entity.CreationTime?.AddHours(TimeZoneConstant.TimeZoneSea);
        CreatorUserId = entity.CreatorUserId;
        UserId = entity.UserId;
        IsDeleted = entity.IsDeleted;
    }

    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public DateTime DoB { get; set; }
    public string Address { get; set; }
    public Guid UserId { get; set; }
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
}