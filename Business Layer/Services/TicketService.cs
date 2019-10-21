using AutoMapper;
using Business_Layer.EntitiesBL;
using DAL.Entities;
using DAL.UoW;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Layer.Services
{

    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TicketBL>> GetAll() => _mapper.Map<List<TicketBL>>(await _unitOfWork.TicketRepository.GetAll());

        public async Task<TicketBL> GetTicketById(int id) => _mapper.Map<TicketBL>(await _unitOfWork.TicketRepository.GetById(id));

        public async Task<TicketBL> AddTicket(TicketBL ticket)
        {
            await _unitOfWork.TicketRepository.Add(_mapper.Map<TicketEntity>(ticket));
            _unitOfWork.Save();
            return await GetTicketById(ticket.Id);
        }

        public async Task DeleteTicket(int id)
        {
            await _unitOfWork.TicketRepository.Delete(id);
            _unitOfWork.Save();
        }


        public async Task<TicketBL> EditTicket(TicketBL ticket)
        {
            await _unitOfWork.TicketRepository.Update(_mapper.Map<TicketEntity>(ticket));
            _unitOfWork.Save();
            return await GetTicketById(ticket.Id);
        }
    }
}
