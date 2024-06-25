using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class BookRepository : BaseRepository<ApplicationDbContext, Book, Guid>, IBookRepository
{
    public BookRepository(ApplicationDbContext dbContext, IServiceProvider serviceProvider) : base(dbContext,
        serviceProvider)
    {
    }
}