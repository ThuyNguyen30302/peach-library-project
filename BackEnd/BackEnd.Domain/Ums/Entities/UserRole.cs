using Microsoft.AspNetCore.Identity;

namespace BackEnd.Domain.Ums.Entities;

public class UserRole : IdentityUserRole<Guid>
{
    public User User { get; set; }

    public Role Role { get; set; }
}