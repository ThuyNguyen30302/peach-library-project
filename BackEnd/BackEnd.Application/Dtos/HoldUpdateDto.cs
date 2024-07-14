using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class HoldUpdateDto: IUpdateDto<Hold, Guid>, IModificationAudited
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid MemberId { get; set; }
    public Guid BookCopyId { get; set; }
    public Guid Id { get; set; }
    public Hold GetEntity(Hold entity)
    {
        entity.Id = Id;
        entity.StartTime = StartTime;
        entity.EndTime = EndTime;
        entity.LastModificationTime = DateTime.Now;
        entity.LastModifierUserId = LastModifierUserId;
        entity.MemberId = MemberId;
        entity.BookCopyId = BookCopyId;
        return entity;
    }

    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
}