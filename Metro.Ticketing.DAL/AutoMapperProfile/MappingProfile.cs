﻿using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO;
using Metro.Ticketing.Domain.RequestDTO.Train;
using Metro.Ticketing.Domain.ResponseDTO;
using Metro.Ticketing.Domain.ResponseDTO.Train;
using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.DAL.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GetAllUserDTO>().ReverseMap();
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<User, EditUserDTO>().ReverseMap();
            CreateMap<User, UserInfoResponseDTO>().ReverseMap();

            CreateMap<Train, GetAllTrainDTO>().ReverseMap();
            CreateMap<Train, CreateTrainDTO>().ReverseMap();
            CreateMap<Train, EditTrainDTO>().ReverseMap();
            CreateMap<Train, TrainInfoResponseDTO>().ReverseMap();


        }
    }
}
