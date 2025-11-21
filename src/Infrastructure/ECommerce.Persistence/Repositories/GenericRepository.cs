using ECommerce.Domain.Common;
using ECommerce.Domain.Interfaces;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            Context = context;
            _dbSet = Context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => 
            await _dbSet.Where(predicate).ToListAsync().ConfigureAwait(false);

        public async Task<IEnumerable<T>> GetAllAsync() => 
            await _dbSet.ToListAsync().ConfigureAwait(false);

        public async Task<T?> GetByIdAsync(int id) => 
            await _dbSet.FindAsync(id).ConfigureAwait(false);

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            Context.SaveChanges();
        }
    }
}