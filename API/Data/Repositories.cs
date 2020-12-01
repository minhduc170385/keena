using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Repositories<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        public Repositories(DbContext context)
        {
            this._context = context;
        }

        public async Task<TEntity> DeleteAsync(int Id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(Id);
            if (entity == null)
            {
                return entity;
            }
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;

        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
