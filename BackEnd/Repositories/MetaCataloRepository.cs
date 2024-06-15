using Abp.EntityFrameworkCore;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public class MetaCataloRepository : Repository<MetaCatalo, Guid>, IMetaCataloRepository
{
    public MetaCataloRepository(IDbContextProvider<MigrationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}