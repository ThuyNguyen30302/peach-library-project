using Abp.Application.Services;
using BackEnd.Base.Service;
using BackEnd.Dtos;
using BackEnd.Entities;

namespace BackEnd.Services;

public interface IBookService : IBaseService<Book, Guid, BookDetailDto,
    BookDetailDto,
    BookCreateDto,
    BookUpdateDto>
{ 
}