namespace BackEnd.Application.Dtos;

public class BorrowedBookDetailDto
{
    public string Title { get; set; }
    public string PublisherName { get; set; }
    public int BorrowedBookAmount { get; set; }
    public int AvailableBookAmount { get; set; }
}