using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Entities;

public class Catalo : Entity<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int DisplayIndex { get; set; }
    public string MetaCataloCode { get; set; }
    public Guid MetaCataloId { get; set; }

    public MetaCatalo MetaCatalo { get; set; }
}
