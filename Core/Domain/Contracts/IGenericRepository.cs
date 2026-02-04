using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity>where TEntity : class
    {
        //get all
        Task<IEnumerable<TEntity>> GetAllAsync();
        //get by id 
        Task<TEntity> GetByIdAsync(int id);
        //add 
        Task AddAsync(TEntity entity);
        //update
        void UpdateAsync(TEntity entity);
        //delete
        void DeleteAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);

          Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predecit, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
    }
}
