using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Dtos;

public class CataloUpdateDto: IUpdateDto<Catalo, Guid>, IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int DisplayIndex { get; set; }
    public string? MetaCataloCode { get; set; }
    public string? Description { get; set; }
    public Guid MetaCataloId { get; set; }
    public Catalo GetEntity(Catalo entity)
    {
        entity.Id = Id;
        entity.Name = string.IsNullOrEmpty(Name) ? Name : entity.Name;
        entity.Code = string.IsNullOrEmpty(Code) ? Code : entity.Code;
        entity.Description = !string.IsNullOrEmpty(Description) ? Description : entity.Description;
        entity.DisplayIndex = entity.DisplayIndex;
        entity.MetaCataloCode = MetaCataloCode;
        entity.MetaCataloId = MetaCataloId;
        return entity;
    }
}