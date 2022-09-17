using Confitec.Core.Domain.Entities;

namespace Confitec.Core.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Table { get; }

        Task CommitAsync();

        Task<TEntity> DeleteAsync(TEntity domain);

        Task<TEntity> FindByIdAsync(int id);

        Task<TEntity> InsertAsync(TEntity domain);

        Task<TEntity> UpdateAsync(TEntity domain);
    }
}
