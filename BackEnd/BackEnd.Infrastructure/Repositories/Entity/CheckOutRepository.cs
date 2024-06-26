using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class CheckOutRepository : BaseRepository<ApplicationDbContext, CheckOut, Guid>, ICheckOutRepository
{
    public CheckOutRepository(ApplicationDbContext dbContext, IServiceProvider serviceProvider) : base(dbContext,
        serviceProvider)
    {
    }
}