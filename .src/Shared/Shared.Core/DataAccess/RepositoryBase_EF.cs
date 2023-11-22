using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Shared.Backend.Core.DataAccess
{
    public class RepositoryBase_EF<TEntity, TContext> : IRepositoryBase<TEntity>
where TEntity : class,  new()
where TContext : DbContext, new()
    {
        private readonly TContext context;
        public RepositoryBase_EF(TContext context)
        {
            this.context = context;
        }


        public async Task<TEntity> AddR(TEntity entity)
        {
            using TContext context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            return (await context.SaveChangesAsync()) > 0 ? entity : throw new Exception("Error AddR SaveChangesAsync");
        }
        public async Task Add(TEntity entity)
        {
            using TContext context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            if (await context.SaveChangesAsync() == 0)
                throw new Exception("Error Add SaveChangesAsync");
        }
        public async Task<IList<TEntity>> AddRangeR(IList<TEntity> entities)
        {
            using TContext context = new TContext();
            await context.AddRangeAsync(entities);
            return (await context.SaveChangesAsync()) > 0 ? entities : throw new Exception("Error AddRangeR SaveChangesAsync");
        }
        public async Task AddRange(IList<TEntity> entities)
        {
            using TContext context = new TContext();
            await context.AddRangeAsync(entities);
            if (await context.SaveChangesAsync() == 0)
                throw new Exception("Error Add SaveChangesAsync");
        }


        public async Task Update(TEntity entity)
        {
            using TContext context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            if (await context.SaveChangesAsync() == 0)
                throw new Exception("Error Update SaveChangesAsync");

        }
        public async Task UpdateRange(IList<TEntity> entities)
        {
            using TContext context = new TContext();
            var updatedEntity = context.Entry(entities);
            updatedEntity.State = EntityState.Modified;
            if (await context.SaveChangesAsync() == 0)
                throw new Exception("Error Update SaveChangesAsync");
        }


        public async Task Delete(TEntity entity)
        {
            using TContext context = new TContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            if (await context.SaveChangesAsync() == 0)
                throw new Exception("Error Update SaveChangesAsync");
        }


        public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, CancellationToken token)
        {
            using TContext context = new TContext();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter, token);
        }
        public async Task<IList<TEntity>> GetPlural(Expression<Func<TEntity, bool>> filter, CancellationToken token)
        {
            using TContext context = new TContext();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync(token)
                : await context.Set<TEntity>().Where(filter).ToListAsync(token);

        }
    }

}
