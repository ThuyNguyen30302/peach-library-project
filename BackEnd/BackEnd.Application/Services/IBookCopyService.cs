using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface IBookCopyService : IBaseService<BookCopy, Guid, BookCopyDetailDto,
    BookCopyDetailDto,
    BookCopyCreateDto,
    BookCopyUpdateDto>
{
    Task<List<BookCopyDetailDto>> CreateBookCopyByAmountAsync(
        List<BookCopyCreateByAmountDto> bookCopyCreateByAmountDtos,
        CancellationToken cancellationToken);

    Task<List<BookCopyDetailTreeDto>> GetBookCopyTreeAsync(CancellationToken cancellationToken);

    Task<List<BookCopyDetailByAmountDto>> GetBookCopyGridAsync(FilterDateRange filter,
        CancellationToken cancellationToken);
}