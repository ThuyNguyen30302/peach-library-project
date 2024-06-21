using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Base.Repositories;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Base.Spectification;

namespace BackEnd.Infrastructure.Base.Service;

public abstract class BaseService<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput,
    TUpdateInput> : IBaseService<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput,
    TUpdateInput>
    where TEntity : Entity<TKey>, IEntity<TKey>
    where TCreateInput : class, ICreateDto<TEntity, TKey>
    where TUpdateInput : class, IUpdateDto<TEntity, TKey>
    where TGetOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TGetListOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TKey : struct
{
    public readonly IBaseRepository<TEntity, TKey> _entityRepository;

    public BaseService(IBaseRepository<TEntity, TKey> entityRepository)
    {
        _entityRepository = entityRepository;
    }

    // public virtual Task<PaginatedList<TGetListOutputDto>> GetListAsync(PaginatedListQuery query,
    //     CancellationToken cancellationToken = default)
    // {
    //     return GetListAsync(query, null, cancellationToken);
    // }

    public virtual async Task<List<TGetListOutputDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var entities = await _entityRepository.GetListAsync(cancellationToken);

        return entities.Select(x =>
        {
            var res = new TGetListOutputDto();

            res.FromEntity(x);

            return res;
        }).ToList();
    }
    
    public virtual async Task<List<TGetListOutputDto>> GetListAsync(ISpecification<TEntity?> specification,
        CancellationToken cancellationToken)
    {
        var entities = await _entityRepository.GetListAsync(specification, cancellationToken);

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

    public virtual async Task<TGetOutputDto> CreateAsync(TCreateInput createInput, CancellationToken cancellationToken)
    {
        var newEntity = createInput.GetEntity();

        await _entityRepository.AddAsync(newEntity, cancellationToken);

        var res = new TGetOutputDto();

        res.FromEntity(newEntity);

        return res;
    }

    public virtual async Task<TGetOutputDto> GetAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await _entityRepository.FirstOrDefaultAsync(id, cancellationToken);

        var res = new TGetOutputDto();

        res.FromEntity(entity);

        return res;
    }

    public virtual async Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput updateInput,
        CancellationToken cancellationToken)
    {
        updateInput.Id = id;
        var entity = await _entityRepository.FirstOrDefaultAsync(id, cancellationToken);

        entity = updateInput.GetEntity(entity);

        await _entityRepository.UpdateAsync(entity, cancellationToken);

        var res = new TGetOutputDto();

        res.FromEntity(entity);

        return res;
    }

    public virtual async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await _entityRepository.FirstOrDefaultAsync(id, cancellationToken);
        await _entityRepository.DeleteAsync(entity, cancellationToken);
    }
}