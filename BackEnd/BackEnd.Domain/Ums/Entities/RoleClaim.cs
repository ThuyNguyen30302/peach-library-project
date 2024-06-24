using Microsoft.AspNetCore.Identity;

namespace BackEnd.Domain.Ums.Entities;

public class RoleClaim : IdentityRoleClaim<Guid>
{
    public Role Role { get; set; }
}