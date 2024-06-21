using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class BookRepository : BaseRepository<ApplicationDbContext, Book, Guid>, IBookRepository
{
    public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}