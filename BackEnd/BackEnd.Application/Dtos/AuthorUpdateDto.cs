using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Dtos;

public class AuthorUpdateDto : IUpdateDto<Author, Guid>, IModificationAudited
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string NickName { get; set; }
    public Author GetEntity(Author entity)
    {
        entity.Id = Id;
        entity.Name = !string.IsNullOrEmpty(Name) ? Name : entity.Name;
        entity.NickName = !string.IsNullOrEmpty(NickName) ? NickName : entity.NickName;
        entity.LastModificationTime = DateTime.Now;
        entity.LastModifierUserId = LastModifierUserId;
        return entity;
    }

    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierUserId { get; set; }
}