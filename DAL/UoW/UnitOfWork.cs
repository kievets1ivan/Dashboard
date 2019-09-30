using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoW
{
    public interface IUnitOfWork
    {
        GenericRepository<TicketEntity> TicketRepository { get; }
        void Dispose();
        void Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private GenericRepository<TicketEntity> _ticketRepository;

        private TicketContext _ticketContext;


        public UnitOfWork(TicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }


        public GenericRepository<TicketEntity> TicketRepository
        {
            get
            {
                if (_ticketRepository == null)
                {
                    _ticketRepository = new GenericRepository<TicketEntity>(_ticketContext);
                }

                return _ticketRepository;
            }
        }

        public void Save()
        {
            _ticketContext.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {                   
                    _ticketContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
