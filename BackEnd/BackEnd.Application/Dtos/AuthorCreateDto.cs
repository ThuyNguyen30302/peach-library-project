using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Dtos;

public class AuthorCreateDto : ICreateDto<Author, Guid>, ICreationAudited
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public Author GetEntity()
    {
        return new Author()
        {
            Name = Name,
            NickName = NickName,
            CreationTime = CreationTime,
            CreatorUserId = CreatorUserId,
        };
    }

    public DateTime? CreationTime { get; set; }
    public Guid? CreatorUserId { get; set; }
}