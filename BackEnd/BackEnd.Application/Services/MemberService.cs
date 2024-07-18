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
                {
                    Id = Guid.NewGuid(), 
                    UserName = createInput.PhoneNumber,
                    EmailAddress = createInput.Email,
                    FullName = createInput.Name,
                    Active = true
                };
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
    
    
    public override async Task<MemberDetailDto> UpdateAsync(Guid id, MemberUpdateDto updateInput, 
        CancellationToken cancellationToken)
    {
        updateInput.Id = id;
        await using var transaction = await _unitOfWork.BeginTransactionAsync();
        try
        {
            var existingMember = await _memberRepository.FirstOrDefaultAsync(id, cancellationToken);
            if (existingMember == null)
            {
                throw new Exception("Không tìm thấy thành viên.");
            }

            // Cập nhật thông tin Member
            existingMember = updateInput.GetEntity(existingMember);
            // Cập nhật các trường khác của Member nếu cần

            await _memberRepository.UpdateAsync(existingMember, cancellationToken);

            // Cập nhật thông tin User tương ứng
            var user = await _userManager.FindByIdAsync(existingMember.UserId.ToString());
            if (user != null)
            {
                user.EmailAddress = updateInput.Email;
                user.FullName = updateInput.Name;
                user.Active = updateInput.Status == "ACTIVE";
                // Cập nhật các trường khác của User nếu cần

                var userUpdateResult = await _userManager.UpdateAsync(user);
                if (!userUpdateResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", userUpdateResult.Errors.Select(e => e.Description)));
                }
            }

            var result = new MemberDetailDto();
            result.FromEntity(existingMember);

            await _unitOfWork.CommitAsync();
            return result;
        }
        catch (Exception e)
        {
            await _unitOfWork.RollbackAsync();
            throw new Exception(e.Message);
        }
    }

    public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _entityRepository.FirstOrDefaultAsync(id, cancellationToken);
        var user = await _userManager.FindByIdAsync(entity.UserId.ToString());

        await _entityRepository.DeleteAsync(entity, cancellationToken);
        await _userManager.DeleteAsync(user);
    }


    public async Task<List<ComboOption<Guid, string>>> GetComboOptionMember(CancellationToken cancellationToken)
    {
        var members =
            await _entityRepository.GetListAsync(
                new Specification<Member>(x => x.Status == "ACTIVE"),
                cancellationToken);

        return members.Select(x => new ComboOption<Guid, string>()
        {
            Value = x.Id,
            Label = x.Name + "-" + x.PhoneNumber
        }).ToList();
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