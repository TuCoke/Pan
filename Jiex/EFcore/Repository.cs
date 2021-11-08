using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.EFcore
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EFCoreContext _dbContext;

        public Repository(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            return true;
        }

        public void DeleteAsync(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbContext.UpdateRange(entities);
        }
    }
    public class Repository<TEntity, TPrimaryKey> : Repository<TEntity>,
   IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntityCore<TPrimaryKey>
    {
        // protected readonly worktimeContext _worktimeContext;

        public Repository(EFCoreContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _dbContext.FindAsync<TEntity>(id);
        }

    }
}
