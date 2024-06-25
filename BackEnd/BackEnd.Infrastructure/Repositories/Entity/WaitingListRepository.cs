using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class WaitingListRepository : BaseRepository<ApplicationDbContext, WaitingList, Guid>, IWaitingListRepository
{
    public WaitingListRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}