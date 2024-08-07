using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class MetaCataloCreateDto: ICreateDto<MetaCatalo, Guid>, ICreationAudited
{
    public MetaCatalo GetEntity()
    {
        return new MetaCatalo()
        {
            Name = Name,
            Code = Code,
            Description = !string.IsNullOrEmpty(Description)?Description:"",
            CreationTime = DateTime.Now,
            CreatorUserId = CreatorUserId,
        };
    }
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Description { get; set; }
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
}