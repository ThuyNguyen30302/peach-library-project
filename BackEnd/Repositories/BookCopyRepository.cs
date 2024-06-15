using Abp.EntityFrameworkCore;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public class BookCopyRepository : Repository<BookCopy, Guid>, IBookCopyRepository
{
    public BookCopyRepository(IDbContextProvider<MigrationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}