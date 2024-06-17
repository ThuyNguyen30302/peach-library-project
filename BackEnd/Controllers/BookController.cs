using Abp.EntityFrameworkCore;
using BackEnd.Base.ApiController;
using BackEnd.Base.Service;
using BackEnd.Dtos;
using BackEnd.Entities;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers;

// [Authorize]
[ApiController]
[Route("/api/book")]
public class BookController : BaseController<Book, Guid, BookDetailDto,
    BookDetailDto,
    BookCreateDto,
    BookUpdateDto>
{
    public BookController(
        IBaseService<Book, Guid, BookDetailDto, BookDetailDto, BookCreateDto, BookUpdateDto> entityService) : base(
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