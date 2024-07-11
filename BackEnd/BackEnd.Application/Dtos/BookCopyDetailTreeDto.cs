using BackEnd.Application.Constant;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class BookCopyDetailTreeDto
{
   public string? CreationTime { get; set; }
   public string? BookName { get; set; }
   public Guid BookId { get; set; }
   public string? PublisherName { get; set; }
   public Guid? PublisherId { get; set; }
   public int Amount { get; set; }
   public DateTime? YearPublisher { get; set; }
   public string? Parent { get; set; }
   public List<BookCopyDetailTreeDto> Children { get; set; }
}