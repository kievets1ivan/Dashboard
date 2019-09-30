using AutoMapper;
using Business_Layer.DTO;
using DAL.Entities;
using DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public interface ITicketService
    {
        void AddTicket(TicketDtoService ticketEntity);
        void DeleteTicket(TicketDtoService ticketEntity);
        void EditTicket(TicketDtoService ticketEntity);
        IEnumerable<TicketDtoService> GetAll();
        TicketDtoService GetTicketById(int id);
    }

    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = AutomapperConfig.ConfigurationMapper();
        }

        public IEnumerable<TicketDtoService> GetAll()
        {
            return _mapper.Map<List<TicketDtoService>>(_unitOfWork.TicketRepository.GetAll());
        }

        public void AddTicket(TicketDtoService ticketEntity)
        {
            _unitOfWork.TicketRepository.Add(_mapper.Map<TicketEntity>(ticketEntity));
            _unitOfWork.Save();
        }

        public void DeleteTicket(TicketDtoService ticketEntity)
        {
            _unitOfWork.TicketRepository.Delete(_mapper.Map<TicketEntity>(ticketEntity));
            _unitOfWork.Save();
        }

        public TicketDtoService GetTicketById(int id)
        {
            return _mapper.Map<TicketDtoService>(_unitOfWork.TicketRepository.GetById(id));
        }

        public void EditTicket(TicketDtoService ticketEntity)
        {
            _unitOfWork.TicketRepository.Update(_mapper.Map<TicketEntity>(ticketEntity));
            _unitOfWork.Save();
        }
    }
}
