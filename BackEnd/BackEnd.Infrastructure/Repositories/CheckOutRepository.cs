using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class CheckOutRepository : BaseRepository<ApplicationDbContext, CheckOut, Guid>, ICheckOutRepository
{
    public CheckOutRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}