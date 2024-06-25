using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class BookCopyRepository : BaseRepository<ApplicationDbContext, BookCopy, Guid>, IBookCopyRepository
{
    public BookCopyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}