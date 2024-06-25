using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Specification;
using BackEnd.Domain.Base.Uow;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Service;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Application.Services;

public class BookService : BaseService<Book, Guid, BookDetailDto,
    BookDetailDto,
    BookCreateDto,
    BookUpdateDto>, IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICataloService _cataloService;

    public BookService(IBookRepository entityRepository, ICataloService cataloService, IUnitOfWork unitOfWork)
        : base(entityRepository)
    {
        _cataloService = cataloService;
        _unitOfWork = unitOfWork;
    }

    public override async Task<List<BookDetailDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var spec = new Specification<Book>();
        spec.AddInclude("BookAuthorMappings.Author");

        var entities = await _entityRepository.GetListAsync(spec, cancellationToken);

        var cataloBookType = await _cataloService.GetComboOptionCodeCatalo("BOOK_TYPE", cancellationToken);

        return entities.Select(x =>
        {
            var res = new BookDetailDto();

            res.FromEntity(x);

            var authors = x.BookAuthorMappings.Select(p => p.Author.Name);
            res.Authors = string.Join(", ", authors);

            var typeSplit = res.Type.Split(",");

            res.Types = string.Join(", ", typeSplit.Select(p =>
            {
                var type = cataloBookType.FirstOrDefault(q => q.Value == p);
                return type?.Label;
            }).ToList());

            // var bookAuthorMappings = new List<BookAuthorMappingDetailDto>();
            // bookAuthorMappings = x.BookAuthorMappings.Select(p =>
            // {
            //     var bookAuthorMapping = new BookAuthorMappingDetailDto();
            //     bookAuthorMapping.FromEntity(p);
            //     return bookAuthorMapping;
            // }).ToList();

            // res.BookAuthorMappings = bookAuthorMappings;
            return res;
        }).ToList();
    }

    // public override async Task<BookDetailDto> CreateAsync(BookCreateDto createInput, CancellationToken cancellationToken)
    // {
    //     var newEntity = createInput.GetEntity();
    //     var dbContext = _entityRepository.GetDbContext();
    //     // Ensure new entity state
    //     dbContext.Entry(newEntity).State = EntityState.Added;
    //
    //     // Add new book author mappings if any
    //     if (newEntity.BookAuthorMappings != null && newEntity.BookAuthorMappings.Any())
    //     {
    //         foreach (var mapping in newEntity.BookAuthorMappings)
    //         {
    //             dbContext.Entry(mapping).State = EntityState.Added;
    //         }
    //     }
    //
    //     await _entityRepository.AddAsync(newEntity, cancellationToken);
    //     await dbContext.SaveChangesAsync(cancellationToken);
    //
    //     var res = new BookDetailDto();
    //     res.FromEntity(newEntity);
    //
    //     return res;
    // }
    
    public override async Task<BookDetailDto> CreateAsync(BookCreateDto createInput,
        CancellationToken cancellationToken)
    {
        var newEntity = createInput.GetEntity();
        await _entityRepository.AddAsync(newEntity, cancellationToken);
    
        var res = new BookDetailDto();
    
        res.FromEntity(newEntity);
    
        return res;
    }
}