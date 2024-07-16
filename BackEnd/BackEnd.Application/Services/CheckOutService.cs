using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Specification;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class CheckOutService: BaseService<CheckOut, Guid, CheckOutDetailDto,
    CheckOutDetailDto,
    CheckOutCreateDto,
    CheckOutUpdateDto>, ICheckOutService
{
    public CheckOutService(ICheckOutRepository entityRepository) : base(entityRepository)
    {
    }
    
    public override async Task<List<CheckOutDetailDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var spec = new Specification<CheckOut>();
        spec.AddInclude("Member");
        spec.AddInclude("BookCopy.Book");
        
        var entities = await _entityRepository.GetListAsync(spec, cancellationToken);

        return entities.Select(x =>
        {
            var res = new CheckOutDetailDto();

            res.FromEntity(x);

            return res;
        }).ToList();
    }
}