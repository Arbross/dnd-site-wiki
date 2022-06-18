using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync<TKey>(TKey id);
        Task<TEntity> GetIncludeAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);
        Task InsertAsync(TEntity entity);
        Task DeleteAsync<TKey>(TKey id);
        Task DeleteAsync(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        Task Save();
    }
}
