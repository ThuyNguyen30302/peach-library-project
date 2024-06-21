using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class CataloRepository : BaseRepository<ApplicationDbContext, Catalo, Guid>, ICataloRepository
{
    public CataloRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}