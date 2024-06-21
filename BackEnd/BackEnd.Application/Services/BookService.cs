using BackEnd.Application.Dtos;
using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class BookService : BaseService<Book, Guid, BookDetailDto,
    BookDetailDto,
    BookCreateDto,
    BookUpdateDto>, IBookService
{
    public BookService(IBookRepository entityRepository) : base(
        entityRepository)
    {
    }
}