using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class WaitingListRepository : BaseRepository<ApplicationDbContext, WaitingList, Guid>, IWaitingListRepository
{
    public WaitingListRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}