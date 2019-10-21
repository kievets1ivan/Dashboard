using System.Collections.Generic;
using System.Threading.Tasks;
using Business_Layer.EntitiesBL;

namespace Business_Layer.Services
{
    public interface ITicketService
    {
        Task<TicketBL> AddTicket(TicketBL ticket);
        Task DeleteTicket(int id);
        Task<TicketBL> EditTicket(TicketBL ticket);
        Task<IEnumerable<TicketBL>> GetAll();
        Task<TicketBL> GetTicketById(int id);
    }
}