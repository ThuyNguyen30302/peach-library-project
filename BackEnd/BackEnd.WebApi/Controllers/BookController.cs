using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("/api/book")]
public class BookController : BaseController<Book, Guid, BookDetailDto,
    BookDetailDto,
    BookCreateDto,
    BookUpdateDto>
{
    public BookController(IBookService entityService) : base(
        entityService)
    {
    }
}


// public class BookController 
// {
//     private readonly MigrationDbContext _dbContext;
//     public BookController(MigrationDbContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//     
//     [HttpGet("index")]
//     public async Task<List<Book>> HandleIndexAction()
//     {
//         var result = await _dbContext.Books.ToListAsync();
//
//         return result;
//     }
// }