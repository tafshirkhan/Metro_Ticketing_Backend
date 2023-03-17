using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO.BankCredential;
using Metro.Ticketing.Domain.RequestDTO.Booking;
using Metro.Ticketing.Domain.ResponseDTO.BankCredential;
using Metro.Ticketing.Domain.ResponseDTO.Booking;
using Metro.Ticketing.Infrastructure.IUnitOfWork;
using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.BL.Business
{
    public class BookingBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<GetAllBookingDTO> GetAllBookings()
        {
            var allBooking = _unitOfWork.BookingRepository.GetAll();
            var allBookingDTO = _mapper.Map<List<GetAllBookingDTO>>(allBooking);
            return allBookingDTO;
        }

        public BookingInfoResponseDTO GetBookingById(Guid bookingId)
        {
            var booking = _unitOfWork.BookingRepository.Get(b => b.BookingId == bookingId);
            var bookingDto = _mapper.Map<BookingInfoResponseDTO>(booking);
            return bookingDto;
        }

        public CreateBookingDTO InsertBooking(CreateBookingDTO bookingDTO)
        {
            var booking = _mapper.Map<Booking>(bookingDTO);
            _unitOfWork.BookingRepository.Insert(booking);
            _unitOfWork.Save();
            return bookingDTO;
        }

        public bool UpdateBooking(EditBookingDTO booking)
        {
            try
            {
                var newBooking = _mapper.Map<Booking>(booking);
                _unitOfWork.BookingRepository.Update(newBooking);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteBooking(Guid bookingId)
        {
            var booking = GetBookingById(bookingId);
            if(booking != null && booking.Status != "CANCELLED")
            {
                booking.Status = "CANCELLED";
                _unitOfWork.BookingRepository.Delete(booking);
                _unitOfWork.Save();
            }
        }

        public double CalculateTrainFare(Guid trainId, Guid passengerId, Guid userId)
        {
            double trainFare = 0;
            var train = _unitOfWork.TrainRepository.Get(t => t.TrainId == trainId);
             Seat seat = _unitOfWork.SeatRepository.Get(t => t.SeatId == trainId);
            
            int totalDistance = (int)train.Distance;
            trainFare = ((totalDistance * 20) + 150 + 50) * 0.20;
            //seat.Total = seat.Total - 1;
            

            Random random = new Random();
            int seatNum = random.Next(1, 72);
            _unitOfWork.BookingRepository.Insert(new Booking {
                TrainId = trainId,
                Status = "PENDING",
                Date = DateTime.Now,
                PassengerId = passengerId,
                UserId = userId,
                SeatNum = seatNum,
                Fare = trainFare,
            });
            _unitOfWork.Save();

            return trainFare;
        }

        public Booking ConfirmBooking(Guid bookingId)
        {
    
            var booking = _unitOfWork.BookingRepository.Get(b => b.BookingId == bookingId);
            if(booking != null)
            {
                booking.Status = "CONFIRM";
                //_unitOfWork.TransactionRepository.Insert(new Transaction {
                //    BookingId = bookingId,
                //    TransactionStatus = "Successful",
                //    Fare = booking.Fare,
                //});
                var newBooking = _mapper.Map<Booking>(booking);
                _unitOfWork.BookingRepository.Update(newBooking);
                _unitOfWork.Save();
            }
            
            return booking;
        }

        public BookingInfoResponseDTO GetBookingByUserId(Guid userId)
        {
            var booking = _unitOfWork.BookingRepository.Get(b => b.UserId == userId);
            var bookingDto = _mapper.Map<BookingInfoResponseDTO>(booking);
            return bookingDto;
        }

        public BookingInfoResponseDTO GetBookingByPassengerId(Guid passemgerId)
        {
            var pBooking = _unitOfWork.BookingRepository.Get(b => b.PassengerId == passemgerId);
            var pBookingDto = _mapper.Map<BookingInfoResponseDTO>(pBooking);
            return pBookingDto;
        }
    }
}
