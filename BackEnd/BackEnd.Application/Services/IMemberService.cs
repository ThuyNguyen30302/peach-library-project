using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface IMemberService: IBaseService<Member, Guid, MemberDetailDto,
    MemberDetailDto,
    MemberCreateDto,
    MemberUpdateDto>
{
    Task<List<ComboOption<Guid, string>>> GetComboOptionMember(CancellationToken cancellationToken);
    Task<List<ComboOption<Guid, string>>> GetComboOptionMemberCanBorrow(CancellationToken cancellationToken);
}