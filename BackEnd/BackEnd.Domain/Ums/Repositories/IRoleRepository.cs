using BackEnd.Domain.Base.Repositories;
using BackEnd.Domain.Ums.Entities;

namespace BackEnd.Domain.Ums.Repositories;

public interface IRoleRepository 
{
    // Task<IEnumerable<User>> GetListUser(List<Guid> ids);
    // Task<IEnumerable<Role>> GetListRole();
    // Task<IEnumerable<UserRole>> GetListUserRole();
    // Task<IEnumerable<Role>> GetListUserRoleByUserId(string userId);
    //
    // /// <summary>
    // ///     Get list roles with user ids
    // /// </summary>
    // /// <param name="userId">List user you need to get roles</param>
    // /// <returns></returns>
    // Task<IEnumerable<Role>> GetRoles(List<string> userId);
    //
    // /// <summary>
    // ///     Get claims by user
    // /// </summary>
    // /// <param name="userId">user id</param>
    // /// <returns>List role claim</returns>
    // Task<IEnumerable<RoleClaim>> GetRoleClaims(string userId);
    //
    // Task<IEnumerable<Role>> GetListUserRoleByListUserId(List<string> userId);
    // Task<IEnumerable<User>> GetListUserByListRoleId(List<Guid> roleIds);
    // Task<IEnumerable<RoleClaim>> GetRoleClaimByListRoleIds(List<Guid> roleIds);
    // Task DeleteUserRoleAsync(List<UserRole> entity);
    // Task AddUserRoleAsync(UserRole entity);
    // Task<IEnumerable<Guid>> GetUserId(IList<Guid> listOfId);
    // Task<IEnumerable<Guid>> GetUserId(string listRoles);
    // Task<List<RoleClaim>> RoleClaimToListAsync(List<string> permission);
}