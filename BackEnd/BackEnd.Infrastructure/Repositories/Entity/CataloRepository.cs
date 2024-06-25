using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class CataloRepository : BaseRepository<ApplicationDbContext, Catalo, Guid>, ICataloRepository
{
    public CataloRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}