using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class BookAuthorMappingRepository : BaseRepository<ApplicationDbContext, BookAuthorMapping, Guid>,
    IBookAuthorMappingRepository
{
    public BookAuthorMappingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}