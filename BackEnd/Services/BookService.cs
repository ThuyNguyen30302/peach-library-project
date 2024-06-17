using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using BackEnd.Base.Service;
using BackEnd.Dtos;
using BackEnd.Entities;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class BookService : BaseService<Book, Guid, BookDetailDto,
    BookDetailDto,
    BookCreateDto,
    BookUpdateDto>, IBookService
{
    public BookService(IBookRepository entityRepository, IUnitOfWorkManager unitOfWorkManager) : base(
        entityRepository, unitOfWorkManager)
    {
    }
}