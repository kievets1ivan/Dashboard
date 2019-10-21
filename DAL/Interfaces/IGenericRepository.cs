using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IGenericEntity
    {
        Task<TEntity> Add(TEntity entity);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity entity);
    }
}