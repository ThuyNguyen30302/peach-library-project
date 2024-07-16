using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
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
    private readonly ICheckOutRepository _checkOutRepository;
    private readonly UserManager<User> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public MemberService(IMemberRepository entityRepository,
        UserManager<User> userManager, IUnitOfWork unitOfWork, IMemberRepository memberRepository,
        ICheckOutRepository checkOutRepository) : base(
        entityRepository)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _memberRepository = memberRepository;
        _checkOutRepository = checkOutRepository;
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

                var user = new User()
                    { UserName = createInput.UserName, EmailAddress = createInput.Email, FullName = createInput.Name };
                var userCreateResult = await _userManager.CreateAsync(user, createInput.Password);

                if (!userCreateResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", userCreateResult.Errors.Select(e => e.Description)));
                }

                createInput.UserId = user.Id;
                createInput.Password = user.PasswordHash;

                var newEntity = createInput.GetEntity();

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

    public async Task<List<ComboOption<Guid, string>>> GetComboOptionMemberCanBorrow(
        CancellationToken cancellationToken)
    {
        var checkOuts = await _checkOutRepository.GetListAsync(new Specification<CheckOut>(x => x.IsReturned == false),
            cancellationToken);

        var borrowedMemberIds = checkOuts.Select(x => x.MemberId).ToList();

        var members =
            await _entityRepository.GetListAsync(
                new Specification<Member>(x => x.Status == "ACTIVE" && !borrowedMemberIds.Contains(x.Id)),
                cancellationToken);

        return members.Select(x => new ComboOption<Guid, string>()
        {
            Value = x.Id,
            Label = x.Name + "-" + x.PhoneNumber
        }).ToList();
    }
}