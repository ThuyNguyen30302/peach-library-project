using Abp.EntityFrameworkCore;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public class HoldRepository : Repository<Hold, Guid>, IHoldRepository
{
    public HoldRepository(IDbContextProvider<MigrationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}