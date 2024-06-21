using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class BookCopyRepository : BaseRepository<ApplicationDbContext, BookCopy, Guid>, IBookCopyRepository
{
    public BookCopyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}