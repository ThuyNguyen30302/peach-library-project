using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class AuthorRepository : BaseRepository<ApplicationDbContext, Author, Guid>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}