using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface ICheckOutService: IBaseService<CheckOut, Guid, CheckOutDetailDto,
    CheckOutDetailDto,
    CheckOutCreateDto,
    CheckOutUpdateDto>
{
    public Task<List<CheckOutDetailDto>> GetListCheckOutAsync(string type, CancellationToken cancellationToken);
    public Task<List<CheckOutDetailDto>> GetCheckOutByMemberAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<CheckOutDetailDto>> GetCheckOutByMemberOverdueAsync(Guid id, CancellationToken cancellationToken);
}