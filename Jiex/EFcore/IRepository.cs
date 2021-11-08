using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.EFcore
{
    public interface IRepository<TEntity>
    {
       // IQueryable<TEntity> GetQueryWithDelete();

        //IQueryable<TEntity> GetQueryWithDisable();
        IQueryable<TEntity> GetQuery();

        // IQueryable<TEntity> GetQueryFromSql(FormattableString sql);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        Task<bool> AddAsync(TEntity entity);

        void DeleteAsync(TEntity entity);

        Task SaveChangesAsync();
    }
    public interface IRepository<TEntity, TPrimaryKey> : IRepository<TEntity> where TEntity : BaseEntityCore<TPrimaryKey>
    {
        Task<TEntity> GetAsync(TPrimaryKey id);
    }
}
