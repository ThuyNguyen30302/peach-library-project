using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface IBookService : IBaseService<Book, Guid, BookDetailDto,
    BookDetailDto,
    BookCreateDto,
    BookUpdateDto>
{ 
    Task<List<ComboOption<Guid, string>>> GetComboOptionBook(CancellationToken cancellationToken);
}