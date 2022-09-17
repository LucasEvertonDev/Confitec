using Confitec.Core.Domain.Entities;
using Confitec.Core.Domain.Interfaces;
using Confitec.Infra.Data.Contexts;

namespace Confitec.Infra.Data.Repositorys
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ApplicationDbContext _applicationDbContext;

        public IQueryable<TEntity> Table => _applicationDbContext.Set<TEntity>().AsQueryable();

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public Task<TEntity> DeleteAsync(TEntity domain)
        {
            _applicationDbContext.Remove(domain);
            return Task.FromResult(domain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _applicationDbContext.Set<TEntity>().FindAsync(id) ?? Activator.CreateInstance<TEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public Task<TEntity> InsertAsync(TEntity domain)
        {
            _applicationDbContext.Add(domain);
            return Task.FromResult(domain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public Task<TEntity> UpdateAsync(TEntity domain)
        {
            _applicationDbContext.Update(domain);
            return Task.FromResult(domain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
