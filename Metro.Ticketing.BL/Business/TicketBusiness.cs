using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO.Booking;
using Metro.Ticketing.Domain.RequestDTO.Ticket;
using Metro.Ticketing.Domain.ResponseDTO.Booking;
using Metro.Ticketing.Domain.ResponseDTO.Ticket;
using Metro.Ticketing.Infrastructure.IUnitOfWork;
using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.BL.Business
{
    public class TicketBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<GetAllTicketDTO> GetAllTickets()
        {
            var allTicket= _unitOfWork.TicketRepository.GetAll();
            var allTicketDTO = _mapper.Map<List<GetAllTicketDTO>>(allTicket);
            return allTicketDTO;
        }

        public TicketInfoResponseDTO GetTicketById(Guid ticketId)
        {
            var ticket = _unitOfWork.TicketRepository.Get(t => t.TicketId == ticketId);
            var ticketDto = _mapper.Map<TicketInfoResponseDTO>(ticket);
            return ticketDto;
        }

        //public void InsertTicket(CreateTicketDTO ticketDTO)
        //{
        //    var ticket = _mapper.Map<Ticket>(ticketDTO);
        //    _unitOfWork.TicketRepository.Insert(ticket);
        //    _unitOfWork.Save();
        //}

        public bool UpdateTicket(EditTicketDTO ticket)
        {
            try
            {
                var newTicket = _mapper.Map<Ticket>(ticket);
                _unitOfWork.TicketRepository.Update(newTicket);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string SaveTicket(Guid passengerId, Guid bookingId, Guid trainId)
        {
            string code = string.Empty;

            try
            {
                _unitOfWork.TicketRepository.Insert(
                new Ticket
                {
                    TrainId = trainId,
                    PassengerId = passengerId,
                    BookingId = bookingId,
                });
                _unitOfWork.Save();
                code = "200";
            }
            catch
            {
                code = "400";
            }
            return code;
        }

        //public IEnumerable<TicketDetails> GetTicket(Guid passengerId, Guid bookingId, Guid trainId)
        //{
        //    List<TicketDetails> ticketDetails;

        //    var p = _unitOfWork.PassengerRepository.Get(p => p.PassengerId == passengerId);
        //    var b = _unitOfWork.BookingRepository.Get(b => b.BookingId == bookingId);
        //    var t = _unitOfWork.TicketRepository.Get(t => t.TrainId == trainId);

        //    ticketDetails = (from pa in _unitOfWork.PassengerRepository
        //                     join bo in _unitOfWork.BookingRepository on )
            
                             
        //    return 0;
        //}
    }
}
