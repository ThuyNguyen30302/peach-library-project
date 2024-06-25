using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class CataloCreateDto: ICreateDto<Catalo, Guid>
{
    public Catalo GetEntity()
    {
        return new Catalo()
        {
            Name = Name,
            Code = Code,
            DisplayIndex = 1,
            MetaCataloCode = string.IsNullOrEmpty(MetaCataloCode)?"":MetaCataloCode,
            Description =  string.IsNullOrEmpty(Description)?"":Description,
            MetaCataloId = MetaCataloId,
        };
    }
    public string Name { get; set; }
    public string Code { get; set; }
    public string? Description { get; set; }
    public int DisplayIndex { get; set; }
    public string? MetaCataloCode { get; set; }
    public Guid MetaCataloId { get; set; }
}