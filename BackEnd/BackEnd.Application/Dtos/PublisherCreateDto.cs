using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Dtos;

public class PublisherCreateDto: ICreateDto<Publisher, Guid>, ICreationAudited
{
    public Publisher GetEntity()
    {
        return new Publisher()
        {
            Name = Name,
            Code = Code,
            CreationTime = CreationTime,
            CreatorUserId = CreatorUserId,
        };
    }

    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
}