using BackEnd.Domain.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class HoldRepository : BaseRepository<ApplicationDbContext, Hold, Guid>, IHoldRepository
{
    public HoldRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}