using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class CheckOutDetailDto: IDetailDto<CheckOut, Guid>, IFullAudited
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsReturned { get; set; }
    public Guid MemberId { get; set; }
    public Guid BookCopyId { get; set; }

    public BookCopy BookCopy { get; set; }
    public Member Member { get; set; }
    public string MemberFullName { get; set; }
    public string TitleBook { get; set; }
    public void FromEntity(CheckOut entity)
    {
        Id = entity.Id;
        StartTime = entity.StartTime;
        EndTime = entity.EndTime;
        IsReturned = entity.IsReturned;
        MemberId = entity.MemberId;
        BookCopyId = entity.BookCopyId;
        BookCopy = entity.BookCopy;
        Member = entity.Member;
        if (entity.Member != null)
        {
            MemberFullName = entity.Member.Name;
        }
        if (entity.BookCopy is { Book: not null })
        {
            TitleBook = entity.BookCopy.Book.Title;
        }
        CreationTime = entity.CreationTime;
        CreatorUserId = entity.CreatorUserId;
        IsDeleted = entity.IsDeleted;
    }

    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public Guid? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
}