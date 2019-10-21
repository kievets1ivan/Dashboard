using DAL.Entities;
using DAL.Repositories;

namespace DAL.UoW
{
    public interface IUnitOfWork
    {
        IGenericRepository<TicketEntity> TicketRepository { get; }

        void Dispose();
        void Save();
    }
}