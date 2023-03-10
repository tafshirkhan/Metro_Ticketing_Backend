﻿using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO;
using Metro.Ticketing.Domain.RequestDTO.Train;
using Metro.Ticketing.Domain.ResponseDTO;
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
    public class TrainBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TrainInfoResponseDTO GetTrainById(Guid trainId)
        {
            var train = _unitOfWork.TrainRepository.Get(t => t.TrainId == trainId);
            var trainDto = _mapper.Map<TrainInfoResponseDTO>(train);
            return trainDto;
        }

        public IEnumerable<GetAllTrainDTO> GetAllTrain()
        {
            var allTrain = _unitOfWork.TrainRepository.GetAll();
            var allTrainDTO = _mapper.Map<List<GetAllTrainDTO>>(allTrain);
            return allTrainDTO;
        }

        public void InsertTrain(CreateTrainDTO trainDTO)
        {
            var train = _mapper.Map<Train>(trainDTO);
            _unitOfWork.TrainRepository.Insert(train);
            _unitOfWork.Save();
        }

        public bool UpdateTrain(EditTrainDTO train)
        {
            try
            {
                var newTrain = _mapper.Map<Train>(train);
                _unitOfWork.TrainRepository.Update(newTrain);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteTrain(Guid trainId)
        {
            var train = GetTrainById(trainId);
            if (train != null)
            {
                _unitOfWork.TrainRepository.Delete(trainId);
                _unitOfWork.Save();
            }
        }


    }
}
