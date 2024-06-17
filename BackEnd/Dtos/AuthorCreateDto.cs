using BackEnd.Base.Dto;
using BackEnd.Entities;

namespace BackEnd.Dtos;

public class AuthorCreateDto : ICreateDto<Author, Guid>
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public Author GetEntity()
    {
        return new Author()
        {
            Name = Name,
            NickName = NickName,
        };
    }
}