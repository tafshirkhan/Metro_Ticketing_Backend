using Metro.Ticketing.BL.Business;
using Metro.Ticketing.Domain.RequestDTO.BankCredential;
using Metro.Ticketing.Domain.RequestDTO.Booking;
using Metro.Ticketing.Domain.ResponseDTO.BankCredential;
using Metro.Ticketing.Domain.ResponseDTO.Booking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro.Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingBusiness _bookingBusiness;

        public BookingController(BookingBusiness bookingBusiness)
        {
            _bookingBusiness = bookingBusiness;
        }


        [HttpGet]
        public IEnumerable<GetAllBookingDTO> GetAllBookingInfo()
        {
            return _bookingBusiness.GetAllBookings();
        }

        [HttpGet("{id}")]
        public ActionResult<BookingInfoResponseDTO> GetBooking(Guid id)
        {
            if (id == null)
                return BadRequest();
            return _bookingBusiness.GetBookingById(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(Guid id, EditBookingDTO booking)
        {
            if (id == null || id != booking.BookingId)
                return BadRequest();
            return Ok(_bookingBusiness.UpdateBooking(booking));
        }

        [HttpPost]
        public IActionResult AddBankBooking(CreateBookingDTO booking)
        {
            _bookingBusiness.InsertBooking(booking);
            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(Guid id)
        {
            if (id == null)
                return BadRequest();
            else
                _bookingBusiness.DeleteBooking(id);
            return Ok();
        }

        [HttpGet("[action]/{trainId}")]
        public IActionResult CalculateTotalFare(Guid trainId, Guid passengerId, Guid userId)
        {
            return Ok(_bookingBusiness.CalculateTrainFare(trainId, passengerId,userId));
        }

        [HttpGet("[action]/{bookingId}")]
        public IActionResult ConfirmBooking(Guid bookingId)
        {
            return Ok(_bookingBusiness.ConfirmBooking(bookingId));
        }

        [HttpGet("[action]/{userId}")]
        public IActionResult BookingByUser(Guid userId)
        {
            return Ok(_bookingBusiness.GetBookingByUserId(userId));
        }

        [HttpGet("[action]/{passengerId}")]
        public IActionResult BookingByPassenger(Guid passengerId)
        {
            return Ok(_bookingBusiness.GetBookingByPassengerId(passengerId));
        }

    }
}
