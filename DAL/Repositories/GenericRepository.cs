using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IGenericEntity
    {
        private TicketContext _context;

        public GenericRepository(TicketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetById(int id) => await _context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);

        public async Task<TEntity> Add(TEntity entity) => await Task.Run(() => _context.Set<TEntity>().Add(entity));

        public async Task Delete(int id) => await Task.Run(() =>
        {
            TEntity entityToDelete = GetById(id).Result;
            _context.Set<TEntity>().Attach(entityToDelete);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
            return _context.Set<TEntity>().Remove(entityToDelete);
        });
        public async Task<TEntity> Update(TEntity entity) => await Task.Run(() => 
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return GetById(entity.Id);
        });
    }
}
