using System.Linq.Expressions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Specifications;
using BackEnd.Base.Dto;

namespace BackEnd.Base.Service;

public abstract class BaseService<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput,
    TUpdateInput> : IBaseService<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput,
    TUpdateInput>
    where TEntity : class, IEntity<TKey>
    where TCreateInput : class, ICreateDto<TEntity, TKey>
    where TUpdateInput : class, IUpdateDto<TEntity, TKey>
    where TGetOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TGetListOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TKey : struct
{
    public readonly IUnitOfWorkManager _unitOfWorkManager;

    public readonly IRepository<TEntity, TKey> _entityRepository;

    public BaseService(IRepository<TEntity, TKey> entityRepository, IUnitOfWorkManager unitOfWorkManager)
    {
        _entityRepository = entityRepository;
        _unitOfWorkManager = unitOfWorkManager;
    }

    // public virtual Task<PaginatedList<TGetListOutputDto>> GetListAsync(PaginatedListQuery query,
    //     CancellationToken cancellationToken = default)
    // {
    //     return GetListAsync(query, null, cancellationToken);
    // }

    public virtual async Task<List<TGetListOutputDto>> GetListAsync()
    {
        var entities = await _entityRepository.GetAllListAsync();

        return entities.Select(x =>
        {
            var res = new TGetListOutputDto();

            res.FromEntity(x);

            return res;
        }).ToList();
    }
    
    public virtual async Task<List<TGetListOutputDto>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = await _entityRepository.GetAllListAsync(predicate);

        return entities.Select(x =>
        {
            var res = new TGetListOutputDto();

            res.FromEntity(x);

            return res;
        }).ToList();
    }

    // public virtual async Task<PaginatedList<TGetListOutputDto>> GetListAsync(PaginatedListQuery query,
    //     ISpecification<TEntity>? specification = null,
    //     CancellationToken cancellationToken = default)
    // {
    //     IQueryable<TEntity> queryable = await _entityRepository.GetQueryableAsync();
    //     if (specification != null)
    //     {
    //         queryable = EfSpecificationEvaluator<TEntity>.GetQuery(queryable, specification);
    //     }
    //
    //     if (query == null)
    //     {
    //         throw new Exception("Paginated filter is required.");
    //     }
    //
    //     queryable = queryable.ApplyPaginatedListQuery(query);
    //
    //     var total = await queryable.CountAsync(cancellationToken);
    //     List<TEntity> entities;
    //     if (query.Limit != -1)
    //     {
    //         entities = await queryable.Skip(query.Offset).Take(query.Limit).ToListAsync(cancellationToken);
    //     }
    //     else
    //     {
    //         entities = await queryable.ToListAsync(cancellationToken);
    //     }
    //
    //     var items = entities.Select(x =>
    //     {
    //         var res = new TGetListOutputDto();
    //
    //         res.FromEntity(x);
    //
    //         return res;
    //     }).ToList();
    //
    //     return new PaginatedList<TGetListOutputDto>(items, total, query.Offset, query.Limit);
    // }

    public virtual async Task<TGetOutputDto> CreateAsync(TCreateInput createInput)
    {
        var newEntity = createInput.GetEntity();

        await _entityRepository.InsertAsync(newEntity);

        var res = new TGetOutputDto();

        res.FromEntity(newEntity);

        return res;
    }

    public virtual async Task<TGetOutputDto> GetAsync(TKey id)
    {
        var entity = await _entityRepository.FirstOrDefaultAsync(id);

        var res = new TGetOutputDto();

        res.FromEntity(entity);

        return res;
    }
    
    public virtual async Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput updateInput)
    {
        var entity = await _entityRepository.FirstOrDefaultAsync(id);

        entity = updateInput.GetEntity(entity);
        
        await _entityRepository.UpdateAsync(entity);

        var res = new TGetOutputDto();

        res.FromEntity(entity);

        return res;
    }

    public virtual async Task DeleteAsync(TKey id)
    {
        var entity = await _entityRepository.FirstOrDefaultAsync(id);
        await _entityRepository.DeleteAsync(entity);
    }
}