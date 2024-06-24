using System.ComponentModel.DataAnnotations;
using BackEnd.Domain.Base.Entities;
using Microsoft.AspNetCore.Identity;

namespace BackEnd.Domain.Ums.Entities;

public class Role : IdentityRole<Guid>
{
    public const string SYSTEM_ADMIN_ROLE = "SYSTEM_ADMIN_ROLE";

    public const string SYSTEM_NOTIFICATION = "SYSTEM_NOTIFICATION";

    [StringLength(511)] public string Code { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; }

    public string Type { get; set; }
}