using Abp.EntityFrameworkCore;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public class CheckOutRepository : Repository<CheckOut, Guid>, ICheckOutRepository
{
    public CheckOutRepository(IDbContextProvider<MigrationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}