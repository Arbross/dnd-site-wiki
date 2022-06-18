using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastracture.Data
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private DatabaseContext context;
        private DbSet<TEntity> dbSet;

        public Repository(DatabaseContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task Save() => await context.SaveChangesAsync();

        public async Task<TEntity> GetIncludeAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).AsNoTracking().ToListAsync();
            }
            else
            {
                return await query.AsNoTracking().ToListAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync<TKey>(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync<TKey>(TKey id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            await DeleteAsync(entityToDelete);
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            await Task.Run(() =>
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            });
        }

        public void Update(TEntity entityToUpdate)
        {
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
