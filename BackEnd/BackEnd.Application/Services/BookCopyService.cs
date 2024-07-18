using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Base.Repositories;
using BackEnd.Domain.Base.Specification;
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
    private readonly ICheckOutRepository _checkOutRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICataloService _cataloService;

    public BookCopyService(IBookCopyRepository entityRepository, ICheckOutRepository checkOutRepository,
        ICataloService cataloService, IBookRepository bookRepository) : base(
        entityRepository)
    {
        _checkOutRepository = checkOutRepository;
        _cataloService = cataloService;
        _bookRepository = bookRepository;
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

    public async Task<int> GetBorrowedBookCopiesAsync(CancellationToken cancellationToken)
    {
        var checkOutQb = _checkOutRepository.GetQueryable().Where(x => !x.IsReturned);
        var checkOuts = await checkOutQb.ToListAsync(cancellationToken);
        var borrowedBookCopyIds = checkOuts.Select(x => x.BookCopyId);
        return borrowedBookCopyIds.Count();
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

    public async Task<List<BorrowedBookDetailDto>> GetListBorrowedBookAsync(CancellationToken cancellationToken)
    {
        var checkOutQb = _checkOutRepository.GetQueryable().Where(x => !x.IsReturned);
        var checkOuts = await checkOutQb.ToListAsync(cancellationToken);
        var borrowedBookCopyIds = checkOuts.Select(x => x.BookCopyId);
        var spec = new Specification<BookCopy>();
        spec.AddInclude("Book");
        spec.AddInclude("Publisher");
        var bookCopies = await _entityRepository.GetListAsync(spec, cancellationToken);
        var groupByBookIdAndPublisherId = bookCopies.GroupBy(x => (x.BookId, x.PublisherId)).ToList();

        var borrowedBookDetails = groupByBookIdAndPublisherId.Select(group =>
        {
            var bookCopy = group.FirstOrDefault();
            var borrowedAmount = borrowedBookCopyIds.Count(id => group.Any(bc => bc.Id == id));

            return new BorrowedBookDetailDto
            {
                Title = bookCopy.Book.Title,
                PublisherName = bookCopy.Publisher.Name,
                BorrowedBookAmount = borrowedAmount,
                AvailableBookAmount = group.Count() - borrowedAmount
            };
        }).ToList();

        return borrowedBookDetails;
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

    public async Task<List<ComboOption<Guid, string>>> GetComboOptionBookCanBorrow(CancellationToken cancellationToken)
    {
        var bookCopyQb = _entityRepository.GetQueryable();
        bookCopyQb = bookCopyQb.Where(x => x.Active)
            .Include(x => x.Book).Include(x => x.Publisher);


        var bookAvailability = await bookCopyQb
            .GroupBy(x => new { x.BookId, x.PublisherId })
            .Select(g => new
            {
                g.Key.BookId,
                g.Key.PublisherId,
                TotalCopies = g.Count(),
                BookCopies = g.ToList(),
                BorrowedCopyIds = _checkOutRepository.GetQueryable().Where(co => !co.IsReturned)
                    .Include(co => co.BookCopy).Select(co => co.BookCopyId).ToList(),
                BorrowedCopiesCount = _checkOutRepository.GetQueryable().Include(co => co.BookCopy)
                    .Count(co => co.BookCopy.BookId == g.Key.BookId &&
                                 co.BookCopy.PublisherId == g.Key.PublisherId &&
                                 !co.IsReturned &&
                                 co.BookCopy.Active)
            })
            .ToListAsync(cancellationToken);

        var availableBooks = bookAvailability
            .Where(b => b.TotalCopies - b.BorrowedCopiesCount > 0)
            .Distinct()
            .ToList();

        return availableBooks.Select(x =>
            {
                var bookCopy = x.BookCopies
                    .FirstOrDefault(p => !x.BorrowedCopyIds.Contains(p.Id));
                return new ComboOption<Guid, string>
                {
                    Value = bookCopy.Id,
                    Label = bookCopy.Book.Title + "-" + bookCopy.Publisher.Name
                };
            })
            .ToList();
    }

    public async Task<List<ComboOption<Guid, string>>> GetComboOptionBookCanBorrowForUpdate(Guid checkOutId,
        CancellationToken cancellationToken)
    {
        var bookCopyQb = _entityRepository.GetQueryable();
        bookCopyQb = bookCopyQb.Where(x => x.Active)
            .Include(x => x.Book).Include(x => x.Publisher);


        var bookAvailability = await bookCopyQb
            .GroupBy(x => new { x.BookId, x.PublisherId })
            .Select(g => new
            {
                g.Key.BookId,
                g.Key.PublisherId,
                TotalCopies = g.Count(),
                BookCopies = g.ToList(),
                BorrowedCopyIds = _checkOutRepository.GetQueryable().Where(co => co.Id != checkOutId && !co.IsReturned)
                    .Include(co => co.BookCopy).Select(co => co.BookCopyId).ToList(),
                BorrowedCopiesCount = _checkOutRepository.GetQueryable().Include(co => co.BookCopy)
                    .Count(co => co.BookCopy.BookId == g.Key.BookId &&
                                 co.BookCopy.PublisherId == g.Key.PublisherId &&
                                 co.Id != checkOutId &&
                                 !co.IsReturned &&
                                 co.BookCopy.Active)
            })
            .ToListAsync(cancellationToken);

        var availableBooks = bookAvailability
            .Where(b => b.TotalCopies - b.BorrowedCopiesCount > 0)
            .Distinct()
            .ToList();

        return availableBooks.Select(x =>
            {
                var bookCopy = x.BookCopies
                    .FirstOrDefault(p => !x.BorrowedCopyIds.Contains(p.Id));
                return new ComboOption<Guid, string>
                {
                    Value = bookCopy.Id,
                    Label = bookCopy.Book.Title + "-" + bookCopy.Publisher.Name
                };
            })
            .ToList();
    }

    public async Task<List<BookListDetailDto>> GetListBookDetail(Guid bookId, CancellationToken cancellationToken)
    {
        var bookCopyQb = _entityRepository.GetQueryable();
        bookCopyQb = bookCopyQb.Where(x => x.BookId == bookId).Include(x => x.Book)
            .ThenInclude(g => g.BookAuthorMappings).ThenInclude(co => co.Author).Include(x => x.Publisher);
        var bookCopies = await bookCopyQb.ToListAsync(cancellationToken);
        var cataloBookType = await _cataloService.GetComboOptionCodeCatalo("BOOK_TYPE", cancellationToken);
        var groupByBookId = bookCopies.GroupBy(x => (x.BookId, x.PublisherId)).ToList();
        var result = groupByBookId.Select(x =>
        {
            var bookCopy = x.FirstOrDefault();
            var authors = bookCopy.Book?.BookAuthorMappings.Select(p => p.Author.Name);
            var typeSplit = bookCopy.Book?.Type.Split(",");
            return new BookListDetailDto()
            {
                Title = bookCopy.Book.Title,
                Authors = authors.Any() ? string.Join(", ", authors) : "",
                Types = typeSplit.Any()
                    ? string.Join(", ", typeSplit.Select(p =>
                    {
                        var type = cataloBookType.FirstOrDefault(q => q.Value == p);
                        return type?.Label;
                    }).ToList())
                    : "",
                PublisherName = bookCopy?.Publisher.Name,
                Amount = x.Count()
            };
        }).ToList();
        if (result.Count == 0)
        {
            var spec = new Specification<Book>(x => x.Id == bookId);
            spec.AddInclude("BookAuthorMappings.Author");
            spec.AddInclude("BookCopies");

            var book = await _bookRepository.FirstOrDefaultAsync(spec,
                cancellationToken);
            var authors = book.BookAuthorMappings.Select(p => p.Author.Name);
            var typeSplit = book.Type.Split(",");
            return new List<BookListDetailDto>
            {
                new BookListDetailDto()
                {
                    Title = book.Title,
                    Authors = authors.Any() ? string.Join(", ", authors) : "",
                    Types = typeSplit.Any()
                        ? string.Join(", ", typeSplit.Select(p =>
                        {
                            var type = cataloBookType.FirstOrDefault(q => q.Value == p);
                            return type?.Label;
                        }).ToList())
                        : "",
                    Amount = 0,
                    PublisherName = ""
                }
            };
        }

        return result;
    }

    public async Task<List<BorrowedBookDetailDto>> GetListBorrowedBookForMemberAsync(string? key,
        CancellationToken cancellationToken)
    {
        var checkOutQb = _checkOutRepository.GetQueryable().Include(x => x.BookCopy)
            .ThenInclude(p => p.Book)
            .Where(x => !x.IsReturned);
        var checkOuts = await checkOutQb.ToListAsync(cancellationToken);
        var borrowedBookCopyIds = checkOuts.Select(x => x.BookCopyId);
        var spec = new Specification<BookCopy>();
        spec.AddInclude("Book");
        spec.AddInclude("Publisher");
        var bookCopies = await _entityRepository.GetListAsync(spec, cancellationToken);
        if (!string.IsNullOrEmpty(key))
        {
            bookCopies = bookCopies.Where(x => x.Book.Title.ToLower().Contains(key.ToLower()));
        }
        var groupByBookIdAndPublisherId = bookCopies.GroupBy(x => (x.BookId, x.PublisherId)).ToList();

        var borrowedBookDetails = groupByBookIdAndPublisherId.Select(group =>
        {
            var bookCopy = group.FirstOrDefault();
            var borrowedAmount = borrowedBookCopyIds.Count(id => group.Any(bc => bc.Id == id));

            return new BorrowedBookDetailDto
            {
                Title = bookCopy.Book.Title,
                PublisherName = bookCopy.Publisher.Name,
                BorrowedBookAmount = borrowedAmount,
                AvailableBookAmount = group.Count() - borrowedAmount,
                Available = group.Count() - borrowedAmount > 0
            };
        }).ToList();

        return borrowedBookDetails;
    }
}