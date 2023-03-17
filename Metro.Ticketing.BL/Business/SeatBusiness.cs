using AutoMapper;
using Metro.Ticketing.Domain.Entities;
using Metro.Ticketing.Domain.RequestDTO.Seat;
using Metro.Ticketing.Domain.RequestDTO.Train;
using Metro.Ticketing.Domain.ResponseDTO.Seat;
using Metro.Ticketing.Domain.ResponseDTO.Train;
using Metro.Ticketing.Infrastructure.IUnitOfWork;
using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.BL.Business
{
    public class SeatBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeatBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public SeatInfoResponseDTO GetSeatById(Guid seatId)
        {
            var seat = _unitOfWork.SeatRepository.Get(s => s.SeatId == seatId);
            var seatDto = _mapper.Map<SeatInfoResponseDTO>(seat);
            return seatDto;
        }

        public IEnumerable<GetAllSeatDTO> GetAllSeat()
        {
            var allSeat = _unitOfWork.SeatRepository.GetAll();
            var allSeatDTO = _mapper.Map<List<GetAllSeatDTO>>(allSeat);
            return allSeatDTO;
        }

        public IEnumerable<SeatDetails> GetAllSeatDetails()
        {
            var train = _unitOfWork.TrainRepository.GetAll();
            var seat = _unitOfWork.SeatRepository.GetAll();

            var seatDetails = (
                from t in train
                join s in seat on t.TrainId equals s.TrainId
                select new SeatDetails
                {
                    TrainId = t.TrainId,
                    SeatId = s.SeatId,
                    TrainName = t.Name,
                    Total = s.Total
                }).ToList();
            return seatDetails;
        }

        public CreateSeatDTO InsertSeat(CreateSeatDTO seatDTO)
        {
            var seat = _mapper.Map<Seat>(seatDTO);
            _unitOfWork.SeatRepository.Insert(seat);
            _unitOfWork.Save();
            return seatDTO;
        }

        public bool UpdateSeat(EditSeatDTO seat)
        {
            try
            {
                var newSeat = _mapper.Map<Seat>(seat);
                _unitOfWork.SeatRepository.Update(newSeat);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteSeat(Guid seatId)
        {
            var seat = GetSeatById(seatId);
            if (seat != null)
            {
                _unitOfWork.SeatRepository.Delete(seatId);
                _unitOfWork.Save();
            }
        }
    }
}
