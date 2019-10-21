using AutoMapper;
using Business_Layer.EntitiesBL;
using Business_Layer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Models;

namespace Web.Controllers
{
    public class TicketController : ApiController
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TicketViewModel>> Get() => _mapper.Map<List<TicketViewModel>>(await _ticketService.GetAll());

        public async Task<TicketViewModel> GetById(int id) => _mapper.Map<TicketViewModel>(await _ticketService.GetTicketById(id));

        public async Task<TicketViewModel> Post(TicketViewModel ticket)
        {
            await _ticketService.AddTicket(_mapper.Map<TicketBL>(ticket));
            return _mapper.Map<TicketViewModel>(_ticketService.GetTicketById(ticket.Id));
        }

        public async Task Delete(int id) => await _ticketService.DeleteTicket(id);

        public async Task<TicketViewModel> Put(TicketViewModel ticket)
        {
            await _ticketService.EditTicket(_mapper.Map<TicketBL>(ticket));
            return _mapper.Map<TicketViewModel>(_ticketService.GetTicketById(ticket.Id));
        }
    }
}
