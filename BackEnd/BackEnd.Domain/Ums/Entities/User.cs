using BackEnd.Domain.Base.Entities;
using Microsoft.AspNetCore.Identity;

namespace BackEnd.Domain.Ums.Entities;

public class User : IdentityUser<Guid>
{
    public override string UserName { get; set; }
    public string EmailAddress { get; set; }
    public bool Active { get; set; }
    public string FullName { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}