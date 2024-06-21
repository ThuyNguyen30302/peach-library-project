using BackEnd.Application.Dtos;
using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class MemberService: BaseService<Member, Guid, MemberDetailDto,
    MemberDetailDto,
    MemberCreateDto,
    MemberUpdateDto>, IMemberService
{
    public MemberService(IMemberRepository entityRepository) : base(
        entityRepository)
    {
    }
}