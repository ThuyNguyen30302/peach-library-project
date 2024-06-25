using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class PublisherUpdateDto: IUpdateDto<Publisher, Guid>, IModificationAudited
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Publisher GetEntity(Publisher entity)
    {
        entity.Id = Id;
        entity.Name = !string.IsNullOrEmpty(Name) ? Name : entity.Name;
        entity.Code = !string.IsNullOrEmpty(Code) ? Code : entity.Code;
        entity.LastModificationTime = DateTime.Now;
        entity.LastModifierUserId = LastModifierUserId;
        return entity;
    }

    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
}