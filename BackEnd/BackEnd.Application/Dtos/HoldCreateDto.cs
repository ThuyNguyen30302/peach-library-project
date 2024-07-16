using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class HoldCreateDto: ICreateDto<Hold, Guid>, ICreationAudited
{
    public Hold GetEntity()
    {
        return new Hold()
        {
            StartTime = StartTime,
            EndTime = EndTime,
            MemberId = MemberId,
            BookCopyId = BookCopyId,
            CreationTime = DateTime.Now,
            CreatorUserId = CreatorUserId,
        };
    }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid MemberId { get; set; }
    public Guid BookCopyId { get; set; }


    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
}