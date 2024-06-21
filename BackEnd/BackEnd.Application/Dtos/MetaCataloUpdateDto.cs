using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Dtos;

public class MetaCataloUpdateDto: IUpdateDto<MetaCatalo, Guid>, IModificationAudited
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public MetaCatalo GetEntity(MetaCatalo entity)
    {
        entity.Id = Id;
        entity.Name = string.IsNullOrEmpty(Name) ? Name : entity.Name;
        entity.Code = string.IsNullOrEmpty(Code) ? Code : entity.Code;
        entity.Description = string.IsNullOrEmpty(Description) ? Description : entity.Description;
        entity.LastModificationTime = LastModificationTime;
        entity.LastModifierUserId = LastModifierUserId;
        return entity;
    }

    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
}