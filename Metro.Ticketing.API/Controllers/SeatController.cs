using Metro.Ticketing.BL.Business;
using Metro.Ticketing.Domain.Entities;
using Metro.Ticketing.Domain.RequestDTO.Seat;
using Metro.Ticketing.Domain.RequestDTO.Train;
using Metro.Ticketing.Domain.ResponseDTO.Seat;
using Metro.Ticketing.Domain.ResponseDTO.Train;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro.Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly SeatBusiness _seatBusiness;

        public SeatController(SeatBusiness seatBusiness)
        {
            _seatBusiness = seatBusiness;
        }

        [HttpGet]
        public IEnumerable<GetAllSeatDTO> GetAllSeatInfo()
        {
            return _seatBusiness.GetAllSeat();
        }

        [HttpGet("{id}")]
        public ActionResult<SeatInfoResponseDTO> GetSeat(Guid id)
        {
            if (id == null)
                return BadRequest();
            return _seatBusiness.GetSeatById(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeat(Guid id, EditSeatDTO seat)
        {
            if (id == null || id != seat.SeatId)
                return BadRequest();
            return Ok(_seatBusiness.UpdateSeat(seat));
        }

        [HttpPost]
        public IActionResult AddSeat(CreateSeatDTO seat)
        {
            _seatBusiness.InsertSeat(seat);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeat(Guid id)
        {
            if (id == null)
                return BadRequest();
            else
                _seatBusiness.DeleteSeat(id);
            return Ok();
        }

        [HttpGet("GetAllSeats")]
        public IEnumerable<SeatDetails> GetAllSetaDetails()
        {
            return _seatBusiness.GetAllSeatDetails();
        }
    }
}
