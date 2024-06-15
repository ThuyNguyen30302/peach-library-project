using Abp.EntityFrameworkCore;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public class CataloRepository : Repository<Catalo, Guid>, ICataloRepository
{
    public CataloRepository(IDbContextProvider<MigrationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}