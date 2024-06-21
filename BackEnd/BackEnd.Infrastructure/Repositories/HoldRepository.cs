using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class HoldRepository : BaseRepository<ApplicationDbContext, Hold, Guid>, IHoldRepository
{
    public HoldRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}