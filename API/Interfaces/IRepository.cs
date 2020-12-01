using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace API.Interfaces
{
    public interface IRepository<TEntity> where TEntity:class
    {      
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int Id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int Id);
        Task<TEntity> UpdateAsync(TEntity entity);


    }
}
