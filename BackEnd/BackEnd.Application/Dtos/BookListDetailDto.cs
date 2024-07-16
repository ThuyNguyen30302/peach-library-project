namespace BackEnd.Application.Dtos;

public class BookListDetailDto
{
    public string Title { get; set; }
    public string Authors { get; set; } 
    public string Types { get; set; } 
    public string PublisherName { get; set; }
    public int? Amount { get; set; }
}