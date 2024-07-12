using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Specification;
using BackEnd.Domain.Base.Uow;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Domain.Ums.Entities;
using BackEnd.Infrastructure.Base.Service;
using Microsoft.AspNetCore.Identity;

namespace BackEnd.Application.Services;

public class MemberService : BaseService<Member, Guid, MemberDetailDto,
    MemberDetailDto,
    MemberCreateDto,
    MemberUpdateDto>, IMemberService
{
    private readonly IMemberRepository _memberRepository;
    private readonly UserManager<User> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public MemberService(IMemberRepository entityRepository,
        UserManager<User> userManager, IUnitOfWork unitOfWork, IMemberRepository memberRepository) : base(
        entityRepository)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _memberRepository = memberRepository;
    }

    public override async Task<MemberDetailDto> CreateAsync(MemberCreateDto createInput,
        CancellationToken cancellationToken)
    {
        await using (var transaction = await _unitOfWork.BeginTransactionAsync())
        {
            try
            {
                var phoneNumberSpec =
                    new Specification<Member>(member => member.PhoneNumber == createInput.PhoneNumber);

                var existingMember = await _memberRepository.FirstOrDefaultAsync(phoneNumberSpec, cancellationToken);

                if (existingMember != null)
                {
                    throw new Exception("Số điện thoại đã được đăng ký.");
                }

                var user = new User() { Id = Guid.NewGuid(), UserName = createInput.PhoneNumber, EmailAddress = createInput.Email, FullName = createInput.Name};
                var userCreateResult = await _userManager.CreateAsync(user, "Peach@" + createInput.PhoneNumber);

                if (!userCreateResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", userCreateResult.Errors.Select(e => e.Description)));
                }

                createInput.UserId = user.Id;

                var newEntity = createInput.GetEntity();
                newEntity.UserName = createInput.PhoneNumber;

                await _entityRepository.AddAsync(newEntity, cancellationToken);

                var result = new MemberDetailDto();

                result.FromEntity(newEntity);

                await _unitOfWork.CommitAsync();

                return result;
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackAsync();

                throw new Exception(e.Message);
            }
        }
    }
    
    public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _entityRepository.FirstOrDefaultAsync(id, cancellationToken);
        var user = await _userManager.FindByIdAsync(entity.UserId.ToString());
        
        await _entityRepository.DeleteAsync(entity, cancellationToken);
        await _userManager.DeleteAsync(user);
    }
    
}