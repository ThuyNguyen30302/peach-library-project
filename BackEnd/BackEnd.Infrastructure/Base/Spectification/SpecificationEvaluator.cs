using System.Linq.Expressions;
using BackEnd.Domain.Base.Specification;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Base.Spectification;

public static class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
    {
        var query = inputQuery;

        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
        }
        else if (specification.OrderByDescending != null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }

        if (specification.IsPagingEnabled)
        {
            query = query.Skip(specification.Skip).Take(specification.Take);
        }

        query = IncludeProperties(query, specification.Includes);

        return query;
    }

    private static IQueryable<T> IncludeProperties(IQueryable<T> query, IEnumerable<Expression<Func<T, object>>> includes)
    {
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }
}