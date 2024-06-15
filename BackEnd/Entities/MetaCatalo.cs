using Abp.Domain.Entities.Auditing;

namespace BackEnd.Entities;

public class MetaCatalo : FullAuditedEntity<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }

    public ICollection<Catalo> Catalos { get; set; }
}