using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO.Passenger;
using Metro.Ticketing.Domain.RequestDTO.Seat;
using Metro.Ticketing.Domain.ResponseDTO.Passenger;
using Metro.Ticketing.Domain.ResponseDTO.Seat;
using Metro.Ticketing.Infrastructure.IUnitOfWork;
using MetroTicketing.System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.BL.Business
{
    public class PassengerBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PassengerBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PassengerInfoResponseDTO GetPassengerById(Guid passengerId)
        {
            var passenger = _unitOfWork.PassengerRepository.Get(p => p.PassengerId == passengerId);
            var passengerDto = _mapper.Map<PassengerInfoResponseDTO>(passenger);
            return passengerDto;
        }

        public IEnumerable<GetAllPassengerDTO> GetAllPassenger()
        {
            var allPassenger = _unitOfWork.PassengerRepository.GetAll();
            var allPassengerDTO = _mapper.Map<List<GetAllPassengerDTO>>(allPassenger);
            return allPassengerDTO;
        }

        public CreatePassengerDTO InsertPassenger(CreatePassengerDTO passengerDTO)
        {
            //passengerDTO.PassengerId = new Guid();
            var passenger = _mapper.Map<Passenger>(passengerDTO);
            _unitOfWork.PassengerRepository.Insert(passenger);
             _unitOfWork.Save();

            return passengerDTO;
        }

        public bool UpdatePassenger(EditPassengerDTO passenger)
        {
            try
            {
                var newPassenger = _mapper.Map<Passenger>(passenger);
                _unitOfWork.PassengerRepository.Update(newPassenger);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeletePassenger(Guid passengerId)
        {
            var passenger = GetPassengerById(passengerId);
            if (passenger != null)
            {
                _unitOfWork.PassengerRepository.Delete(passengerId);
                _unitOfWork.Save();
            }
        }

        
        public IEnumerable<Report> GetReport(Guid trainId)
        {
            var passenger = _unitOfWork.PassengerRepository.GetAll();
            var booking = _unitOfWork.BookingRepository.GetAll();
            var reportDetails = (
                from p in passenger
                join b in booking on p.PassengerId equals b.PassengerId
                where b.TrainId == trainId
                select new Report
                { 
                    PassengerId = p.PassengerId,
                    PassengerName = p.PassengerName,
                    Age = p.Age,
                    Gender = p.Gender,
                    BookingId = b.BookingId,
                    Fare = b.Fare,
                    Date = b.Date,
                    Status = b.Status,
                    SeatNum = b.SeatNum  
                }).ToList();
            return reportDetails;
                
        }
    }
}
