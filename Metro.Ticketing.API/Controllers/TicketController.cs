using Metro.Ticketing.BL.Business;
using Metro.Ticketing.Domain.RequestDTO.Booking;
using Metro.Ticketing.Domain.RequestDTO.Passenger;
using Metro.Ticketing.Domain.RequestDTO.Ticket;
using Metro.Ticketing.Domain.ResponseDTO.Booking;
using Metro.Ticketing.Domain.ResponseDTO.Ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro.Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketBusiness _ticketBusiness;

        public TicketController(TicketBusiness ticketBusiness)
        {
            _ticketBusiness = ticketBusiness;
        }

        [HttpGet]
        public IEnumerable<GetAllTicketDTO> GetAllTicketInfo()
        {
            return _ticketBusiness.GetAllTickets();
        }

        [HttpGet("{id}")]
        public ActionResult<TicketInfoResponseDTO> GetTicket(Guid id)
        {
            if (id == null)
                return BadRequest();
            return _ticketBusiness.GetTicketById(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(Guid id, EditTicketDTO ticket)
        {
            if (id == null || id != ticket.TicketId)
                return BadRequest();
            return Ok(_ticketBusiness.UpdateTicket(ticket));
        }

        //[HttpPost]
        //public IActionResult AddTicket(CreateTicketDTO ticket)
        //{
        //    _ticketBusiness.InsertTicket(ticket);
        //    return Ok();
        //}

        [HttpGet("SaveTicket")]
        public IActionResult SaveTicket(Guid passengerId, Guid bookingId, Guid trainId)
        {
            return Ok(_ticketBusiness.SaveTicket(passengerId,bookingId, trainId));
        }
    }
}
