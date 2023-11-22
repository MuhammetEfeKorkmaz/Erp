using System.Linq.Expressions;

namespace Shared.Backend.Core.DataAccess
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        Task<IList<T>> GetPlural(Expression<Func<T, bool>> filter, CancellationToken token);
        Task<T> GetSingle(Expression<Func<T, bool>> filter, CancellationToken token);


        Task<T> AddR(T entity);
        Task Add(T entity);
        Task<IList<T>> AddRangeR(IList<T> entities);
        Task AddRange(IList<T> entities);
        Task Update(T entity);
        Task UpdateRange(IList<T> entities);
        Task Delete(T entity);
    }
}
