using BackEnd.Domain.Ums.Entities;
using BackEnd.Domain.Ums.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Ums;

public class UserRepository : IUserRepository
{
    public UserRepository(ApplicationDbContext dbContextProvider, IServiceProvider serviceProvider)
    {
    }

    // public async Task<User> GetUserWithAuthInfo(Guid id)
    // {
    //     var dbSet = await GetDbSetAsync();
    //     return await dbSet.Include(x => x.Employee)
    //         .Include(x => x.UserRoles)
    //         .ThenInclude(x => x.Role)
    //         .FirstOrDefaultAsync(x => x.Id == id && x.Active);
    // }
    //
    // public Task<IQueryable<User>> GetQueryable(ISpecification<User> specification = null)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public async Task<IQueryable<User>> GetQueryable(bool isTracking = true,
    //     ISpecification<User> specification = null)
    // {
    //     var context = await DbContextProvider.GetDbContextAsync();
    //     var baseQuery = isTracking
    //         ? context.Set<User>().AsQueryable()
    //         : context.Set<User>().AsNoTracking().AsQueryable();
    //
    //
    //     return specification == null
    //         ? baseQuery
    //         : EfSpecificationEvaluator<User>.GetQuery(baseQuery, specification);
    // }
    //
    //
    // public override async Task<IQueryable<User>> WithDetailsAsync()
    // {
    //     return (await GetQueryableAsync()).Include(x => x.UserRoles).ThenInclude(x => x.Role);
    // }
    //
    // public async Task ClearAllStateAliveAsync()
    // {
    //     await _easySql.Update<User>()
    //         .Where(x => x.Alive == true)
    //         .Set(x => x.Alive, false)
    //         .ExecuteAffrowsAsync();
    // }
    //
    // public async Task<IQueryable<UserView>> GetUserViewQueryable()
    // {
    //     var dbContext = await GetDbContextAsync();
    //     return dbContext.Set<UserView>().AsQueryable();
    // }
    //
    // private async Task InitializeAsync()
    // {
    //     var dbContextAsync = await DbContextProvider.GetDbContextAsync();
    //     _easySql = dbContextAsync.EasyQuery();
    // }
}