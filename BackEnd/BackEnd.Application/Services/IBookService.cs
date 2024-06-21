using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Services;

public interface IBookService : IBaseService<Book, Guid, BookDetailDto,
    BookDetailDto,
    BookCreateDto,
    BookUpdateDto>
{ 
}