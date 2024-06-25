using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class AuthorRepository : BaseRepository<ApplicationDbContext, Author, Guid>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}