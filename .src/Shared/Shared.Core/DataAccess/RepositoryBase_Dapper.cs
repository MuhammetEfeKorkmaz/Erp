using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Shared.Backend.Core.DataAccess
{
    public class RepositoryBase_Dapper<TEntity, TContext> : IRepositoryBase<TEntity>
where TEntity : class, new()
where TContext : DbContext, new()
    {
        private readonly TContext context;
        public RepositoryBase_Dapper(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddR(TEntity entity)
        {
            return await Task.FromResult(entity);
        }
        public async Task Add(TEntity entity)
        {
            await Task.FromResult(0);
        }
        public async Task<IList<TEntity>> AddRangeR(IList<TEntity> entities)
        {
            return await Task.FromResult(entities);
        }
        public async Task AddRange(IList<TEntity> entities)
        {
            await Task.FromResult(0);
        }


        public async Task Update(TEntity entity)
        {
            await Task.FromResult(0);
        }
        public async Task UpdateRange(IList<TEntity> entities)
        {
            await Task.FromResult(0);
        }


        public async Task Delete(TEntity entity)
        {
            await Task.FromResult(0);
        }


        public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, CancellationToken token)
        {
            TEntity entity = new();
            return await Task.FromResult(entity);
        }
        public async Task<IList<TEntity>> GetPlural(Expression<Func<TEntity, bool>> filter, CancellationToken token)
        {
            IList<TEntity> entities = new List<TEntity>();
            return await Task.FromResult(entities);
        }






    }

}
