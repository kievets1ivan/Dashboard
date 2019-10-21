using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoW
{

    public class UnitOfWork : IUnitOfWork
    {
        private IRepositoryFactory<IGenericRepository<TicketEntity>, DbContext> _factory;
        private IGenericRepository<TicketEntity> _ticketRepository;

        private TicketContext _ticketContext;


        public UnitOfWork(TicketContext ticketContext, IRepositoryFactory<IGenericRepository<TicketEntity>, DbContext> factory)
        {
            _factory = factory;
            _ticketContext = ticketContext;
        }


        public IGenericRepository<TicketEntity> TicketRepository
        {
            get
            {
                if (_ticketRepository == null)
                {
                    _ticketRepository = _factory.Create(_ticketContext);
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
