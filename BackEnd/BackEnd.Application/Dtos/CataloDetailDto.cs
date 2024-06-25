using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class CataloDetailDto: IDetailDto<Catalo, Guid>, IEntity<Guid>
{
    public void FromEntity(Catalo entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Code = entity.Code;
        DisplayIndex = entity.DisplayIndex;
        MetaCataloCode = entity.MetaCataloCode;
        MetaCataloId = entity.MetaCataloId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int DisplayIndex { get; set; }
    public string MetaCataloCode { get; set; }
    public Guid MetaCataloId { get; set; }
}