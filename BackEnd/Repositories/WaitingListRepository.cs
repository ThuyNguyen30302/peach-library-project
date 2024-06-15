using Abp.EntityFrameworkCore;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public class WaitingListRepository : Repository<WaitingList, Guid>, IWaitingListRepository
{
    public WaitingListRepository(IDbContextProvider<MigrationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}