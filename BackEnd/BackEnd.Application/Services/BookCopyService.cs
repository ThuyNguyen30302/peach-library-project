using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Base.Repositories;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Service;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Application.Services;

public class BookCopyService : BaseService<BookCopy, Guid, BookCopyDetailDto,
    BookCopyDetailDto,
    BookCopyCreateDto,
    BookCopyUpdateDto>, IBookCopyService
{
    public BookCopyService(IBookCopyRepository entityRepository) : base(entityRepository)
    {
    }

    public async Task<List<BookCopyDetailDto>> CreateBookCopyByAmountAsync(
        List<BookCopyCreateByAmountDto> bookCopyCreateByAmountDtos,
        CancellationToken cancellationToken)
    {
        var bookCopies = new List<BookCopy>();

        foreach (var bookCopyCreateByAmountDto in bookCopyCreateByAmountDtos)
        {
            var amount = bookCopyCreateByAmountDto.Amount;
            for (var i = 0; i < amount; i++)
            {
                var bookCopy = bookCopyCreateByAmountDto.GetEntity();
                bookCopies.Add(bookCopy);
            }
        }

        await _entityRepository.AddRangeAsync(bookCopies, cancellationToken);

        var result = bookCopies.Select(x =>
        {
            var res = new BookCopyDetailDto();
            res.FromEntity(x);
            return res;
        }).ToList();

        return result;
    }

    public async Task<List<BookCopyDetailTreeDto>> GetBookCopyTreeAsync(CancellationToken cancellationToken)
    {
        var bookCopyQb = _entityRepository.GetQueryable();
        bookCopyQb = bookCopyQb.Include(x => x.Book).Include(x => x.Publisher).OrderByDescending(x => x.CreationTime);
        var bookCopies = await bookCopyQb.ToListAsync(cancellationToken);
        var groupByCreationTime = bookCopies.GroupBy(x => x.CreationTime.Value.ToString("yyyy-MM-dd"));

        var result = new List<BookCopyDetailTreeDto>();
        foreach (var groupByCreationTimeItem in groupByCreationTime)
        {
            var item1 = new BookCopyDetailTreeDto()
            {
                CreationTime = groupByCreationTimeItem.Key,
            };

            var childrenItem1 = new List<BookCopyDetailTreeDto>();

            var groupByCreationTimeHasTime = groupByCreationTimeItem.ToList()
                .GroupBy(x => x.CreationTime.Value.ToString("yyyy-MM-dd HH:mm"));

            foreach (var groupByCreationTimeHasTimeItem in groupByCreationTimeHasTime)
            {
                var item2 = new BookCopyDetailTreeDto()
                {
                    CreationTime = groupByCreationTimeHasTimeItem.Key,
                };

                var childrenItem2 = new List<BookCopyDetailTreeDto>();


                var groupByBookId = groupByCreationTimeHasTimeItem.ToList().GroupBy(x => (x.BookId, x.PublisherId));
                foreach (var groupByBookIdItem in groupByBookId)
                {
                    var item3 = new BookCopyDetailTreeDto()
                    {
                        BookId = groupByBookIdItem.Key.BookId,
                        BookName = groupByBookIdItem.FirstOrDefault()?.Book.Title,
                        PublisherId = groupByBookIdItem.Key.PublisherId,
                        PublisherName = groupByBookIdItem.FirstOrDefault()?.Publisher.Name,
                        YearPublisher = groupByBookIdItem.FirstOrDefault()?.YearPublisher,
                        Amount = groupByBookIdItem.ToList().Count,
                        Parent = groupByCreationTimeHasTimeItem.Key
                    };

                    childrenItem2.Add(item3);
                }

                item2.Children = childrenItem2;
                item2.Parent = groupByCreationTimeItem.Key;

                childrenItem1.Add(item2);
            }

            item1.Children = childrenItem1;

            result.Add(item1);
        }

        return result;
    }

    public async Task<List<BookCopyDetailByAmountDto>> GetBookCopyGridAsync(FilterDateRange filter,
        CancellationToken cancellationToken)
    {
        var bookCopyQb = _entityRepository.GetQueryable();
        bookCopyQb = bookCopyQb
            .Where(x => x.CreationTime != null &&
                        x.CreationTime.Value.Date >= filter.StartDate.Date &&
                        x.CreationTime.Value.Date <= filter.EndDate.Date)
            .Include(x => x.Book)
            .Include(x => x.Publisher)
            .OrderByDescending(x => x.CreationTime);
        var bookCopies = await bookCopyQb.ToListAsync(cancellationToken);
        var groupByCreationTime = bookCopies.GroupBy(x => x.CreationTime?.ToString("yyyy-MM-dd"));

        var result = new List<BookCopyDetailByAmountDto>();
        foreach (var groupByCreationTimeItem in groupByCreationTime)
        {
            var groupByCreationTimeHasTime = groupByCreationTimeItem.ToList()
                .GroupBy(x => x.CreationTime?.ToString("yyyy-MM-dd HH:mm"));

            foreach (var groupByCreationTimeHasTimeItem in groupByCreationTimeHasTime)
            {
                var groupByBookId = groupByCreationTimeHasTimeItem.ToList().GroupBy(x => (x.BookId, x.PublisherId));
                foreach (var groupByBookIdItem in groupByBookId)
                {
                    result.Add(new BookCopyDetailByAmountDto()
                    {
                        BookId = groupByBookIdItem.Key.BookId,
                        BookName = groupByBookIdItem.FirstOrDefault()?.Book.Title,
                        PublisherId = groupByBookIdItem.Key.PublisherId,
                        PublisherName = groupByBookIdItem.FirstOrDefault()?.Publisher.Name,
                        YearPublisher = groupByBookIdItem.FirstOrDefault()?.YearPublisher,
                        Amount = groupByBookIdItem.ToList().Count,
                        CreationTime = groupByCreationTimeHasTimeItem.FirstOrDefault().CreationTime.ToString()
                    });
                }
            }
        }

        return result;
    }
}