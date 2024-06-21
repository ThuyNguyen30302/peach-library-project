using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Services;

public interface IMemberService: IBaseService<Member, Guid, MemberDetailDto,
    MemberDetailDto,
    MemberCreateDto,
    MemberUpdateDto>
{ 
}