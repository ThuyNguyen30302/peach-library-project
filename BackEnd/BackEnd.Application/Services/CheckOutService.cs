using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Specification;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Service;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Application.Services;

public class CheckOutService : BaseService<CheckOut, Guid, CheckOutDetailDto,
    CheckOutDetailDto,
    CheckOutCreateDto,
    CheckOutUpdateDto>, ICheckOutService
{
    public CheckOutService(ICheckOutRepository entityRepository) : base(entityRepository)
    {
    }

    public override async Task<List<CheckOutDetailDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var checkOutQb = _entityRepository.GetQueryable().Include(x => x.Member).Include(x => x.BookCopy)
            .ThenInclude(p => p.Book).OrderBy(x => x.IsReturned).ThenByDescending(x => x.CreationTime);
        var entities = await checkOutQb.ToListAsync(cancellationToken);

        return entities.Select(x =>
        {
            var res = new CheckOutDetailDto();

            res.FromEntity(x);

            return res;
        }).ToList();
    }
}