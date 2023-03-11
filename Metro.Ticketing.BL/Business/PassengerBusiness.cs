using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO.Passenger;
using Metro.Ticketing.Domain.RequestDTO.Seat;
using Metro.Ticketing.Domain.ResponseDTO.Passenger;
using Metro.Ticketing.Domain.ResponseDTO.Seat;
using Metro.Ticketing.Infrastructure.IUnitOfWork;
using MetroTicketing.System.Entities;
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

        public void InsertPassenger(CreatePassengerDTO passengerDTO)
        {
            var passenger = _mapper.Map<Passenger>(passengerDTO);
            _unitOfWork.PassengerRepository.Insert(passenger);
            _unitOfWork.Save();
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
    }
}
