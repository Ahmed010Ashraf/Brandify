using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace presistance.Repositories
{
    public class GenericReposatory<TEntity>(BrandifyDbContext _context) : IGenericRepository<TEntity>where TEntity : class
    {
        public async Task AddAsync(TEntity entity)
        {   
               await _context.Set<TEntity>().AddAsync(entity);
        }

        public  void DeleteAsync(TEntity entity)
        {
              _context.Set<TEntity>().Remove(entity);
            
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null )
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if(include != null)
            {
                query = include(query);
            }
                return await query.ToListAsync();
            
        }

        public async Task<TEntity> GetByIdAsync(Expression <Func<TEntity,bool>> predecit, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if(include != null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync(predecit);
        }


        public void UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
