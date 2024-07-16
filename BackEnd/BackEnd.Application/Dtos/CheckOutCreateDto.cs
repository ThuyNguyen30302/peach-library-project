using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class CheckOutCreateDto: ICreateDto<CheckOut, Guid>, ICreationAudited
{
    public CheckOut GetEntity()
    {
        return new CheckOut()
        {
            IsReturned = false,
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