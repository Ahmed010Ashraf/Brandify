using Domain.Contracts;
using presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presistance.Repositories
{
    public class UniteOfWork(BrandifyDbContext _context) : IUnitOfWork
    {
        private readonly Dictionary<string,object> _repositories = new();
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var name = typeof(TEntity).Name;
            if(_repositories.ContainsKey(name))
            {
                return (IGenericRepository<TEntity>)_repositories[name];
            }
            _repositories.Add(name,new GenericReposatory<TEntity>(_context));
            return (IGenericRepository<TEntity>)_repositories[name];
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
