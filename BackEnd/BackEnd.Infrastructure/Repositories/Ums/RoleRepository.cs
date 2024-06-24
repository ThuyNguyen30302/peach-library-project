using BackEnd.Domain.Ums.Entities;
using BackEnd.Domain.Ums.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Ums;

public sealed class RoleRepository : IRoleRepository
{
    // public const string PermissionClaimType = "Permission";
    //
    // public RoleRepository(ApplicationDbContext dbContextProvider,
    //     IServiceProvider serviceProvider) 
    // {
    // }
    //
    // public Task<IEnumerable<User>> GetListUser(List<Guid> ids)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public async Task<IEnumerable<Role>> GetListRole()
    // {
    //     var queryableAsync = await GetQueryableAsync();
    //     var result = await queryableAsync.AsNoTracking()
    //         .Include(x => x.UserRoles)
    //         .ToListAsync();
    //     return result;
    // }
    //
    // public override async Task<IQueryable<Role>> WithDetailsAsync()
    // {
    //     return (await GetQueryableAsync()).Include(x => x.UserRoles);
    // }
    //
    // public Task<IEnumerable<UserRole>> GetListUserRole()
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<IEnumerable<Role>> GetListUserRoleByUserId(string userId)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public async Task<IEnumerable<Role>> GetRoles(List<string> userId)
    // {
    //     var dbContextAsync = await DbContextProvider.GetDbContextAsync();
    //     var userRoles = dbContextAsync.Set<UserRole>();
    //     var result = await userRoles.AsNoTracking()
    //         .Where(x => userId.Contains(x.UserId.ToString()))
    //         .Select(x => x.Role)
    //         .Distinct()
    //         .ToListAsync();
    //     return result;
    // }
    //
    // public async Task<IEnumerable<RoleClaim>> GetRoleClaims(string userId)
    // {
    //     var dbContextAsync = await DbContextProvider.GetDbContextAsync();
    //     var userRoles = dbContextAsync.Set<UserRole>();
    //     var roles = await userRoles.AsNoTracking()
    //         .Include(x => x.Role)
    //         .Where(x => userId.Contains(x.UserId.ToString()))
    //         .Select(x => x.Role.Id)
    //         .Distinct()
    //         .ToListAsync();
    //     var useRoleClaim = dbContextAsync.Set<RoleClaim>();
    //     var roleClaims = await useRoleClaim.AsNoTracking()
    //         .Where(x => roles.Contains(x.RoleId))
    //         .ToListAsync();
    //     return roleClaims;
    // }
    //
    // public async Task<IEnumerable<Role>> GetListUserRoleByListUserId(List<string> userId)
    // {
    //     var dbContextAsync = await DbContextProvider.GetDbContextAsync();
    //     var result = await dbContextAsync.Set<UserRole>().AsQueryable()
    //         .AsNoTracking()
    //         .Where(x => userId.Contains(x.UserId.ToString()))
    //         .Select(x => x.Role)
    //         .Distinct()
    //         .ToListAsync();
    //     return result;
    // }
    //
    // public Task<IEnumerable<User>> GetListUserByListRoleId(List<Guid> roleIds)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public async Task<IEnumerable<RoleClaim>> GetRoleClaimByListRoleIds(List<Guid> roleIds)
    // {
    //     var allClaims = await (await DbContextProvider.GetDbContextAsync()).Set<RoleClaim>()
    //         .AsQueryable()
    //         .AsNoTracking()
    //         .Include(x => x.Role)
    //         .Where(x => roleIds.Contains(x.RoleId) &&
    //                     x.ClaimType == PermissionClaimType)
    //         .ToListAsync();
    //     return allClaims;
    // }
    //
    // public Task DeleteUserRoleAsync(List<UserRole> entity)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task AddUserRoleAsync(UserRole entity)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<IEnumerable<Guid>> GetUserId(IList<Guid> listOfId)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<IEnumerable<Guid>> GetUserId(string listRoles)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<List<RoleClaim>> RoleClaimToListAsync(List<string> permission)
    // {
    //     throw new NotImplementedException();
    // }
}