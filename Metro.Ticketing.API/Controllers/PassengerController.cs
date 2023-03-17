using Metro.Ticketing.BL.Business;
using Metro.Ticketing.Domain.RequestDTO.Passenger;
using Metro.Ticketing.Domain.RequestDTO.Seat;
using Metro.Ticketing.Domain.ResponseDTO.Passenger;
using Metro.Ticketing.Domain.ResponseDTO.Seat;
using MetroTicketing.System.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro.Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerBusiness _passengerBusiness;

        public PassengerController(PassengerBusiness passengerBusiness)
        {
            _passengerBusiness = passengerBusiness;
        }


        [HttpGet]
        public IEnumerable<GetAllPassengerDTO> GetAllPassengerInfo()
        {
            return _passengerBusiness.GetAllPassenger();
        }

        [HttpGet("{id}")]
        public ActionResult<PassengerInfoResponseDTO> GetPassenger(Guid id)
        {
            if (id == null)
                return BadRequest();
            return _passengerBusiness.GetPassengerById(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePassenger(Guid id, EditPassengerDTO passenger)
        {
            if (id == null || id != passenger.PassengerId)
                return BadRequest();
            return Ok(_passengerBusiness.UpdatePassenger(passenger));
        }

        [HttpPost("SavePassenger")]
        public IActionResult AddPassenger(CreatePassengerDTO passenger)
        {
            _passengerBusiness.InsertPassenger(passenger);
            return Ok(passenger);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePassenger(Guid id)
        {
            if (id == null)
                return BadRequest();
            else
                _passengerBusiness.DeletePassenger(id);
            return Ok();
        }

        [HttpGet("GetReport")]
        public IEnumerable<Report> GetReport(Guid trainId)
        {
            return _passengerBusiness.GetReport(trainId);
        }
    }
}
