using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IGenericModel
    {
        void Add(TEntity ticket);
        void Delete(TEntity ticket);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity ticket);
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IGenericModel
    {
        private TicketContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(TicketContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList().AsQueryable();
        }

        public TEntity GetById(int id)
        {
            TEntity ticket = _dbSet.FirstOrDefault(x => x.Id == id);
            if (ticket == null)
            {
                throw new Exception("Error");
            }

            return ticket;
        }

        public void Update(TEntity ticket)
        {
            _dbSet.Attach(GetById(ticket.Id));
        }

        public void Add(TEntity ticket)
        {
            _dbSet.Add(ticket);
        }

        public void Delete(TEntity ticket)
        {
            _dbSet.Remove(ticket);
        }

    }
}
