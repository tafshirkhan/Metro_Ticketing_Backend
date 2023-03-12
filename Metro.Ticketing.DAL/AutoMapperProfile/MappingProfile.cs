using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO;
using Metro.Ticketing.Domain.RequestDTO.BankCredential;
using Metro.Ticketing.Domain.RequestDTO.Booking;
using Metro.Ticketing.Domain.RequestDTO.Passenger;
using Metro.Ticketing.Domain.RequestDTO.Seat;
using Metro.Ticketing.Domain.RequestDTO.Ticket;
using Metro.Ticketing.Domain.RequestDTO.Train;
using Metro.Ticketing.Domain.RequestDTO.Transaction;
using Metro.Ticketing.Domain.ResponseDTO;
using Metro.Ticketing.Domain.ResponseDTO.BankCredential;
using Metro.Ticketing.Domain.ResponseDTO.Booking;
using Metro.Ticketing.Domain.ResponseDTO.Passenger;
using Metro.Ticketing.Domain.ResponseDTO.Seat;
using Metro.Ticketing.Domain.ResponseDTO.Ticket;
using Metro.Ticketing.Domain.ResponseDTO.Train;
using Metro.Ticketing.Domain.ResponseDTO.Transaction;
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

            CreateMap<Seat, GetAllSeatDTO>().ReverseMap();
            CreateMap<CreateSeatDTO, Seat>().ReverseMap();
            CreateMap<Seat, EditSeatDTO>().ReverseMap();
            CreateMap<Seat, SeatInfoResponseDTO>().ReverseMap();

            CreateMap<Passenger, GetAllPassengerDTO>().ReverseMap();
            CreateMap<CreatePassengerDTO, Passenger>().ReverseMap();
            CreateMap<Passenger, EditPassengerDTO>().ReverseMap();
            CreateMap<Passenger, PassengerInfoResponseDTO>().ReverseMap();

            CreateMap<BankCredential, GetAllBankCredentialDTO>().ReverseMap();
            CreateMap<CreateBankCredentialDTO, BankCredential>().ReverseMap();
            CreateMap<BankCredential, EditBankCredentialDTO>().ReverseMap();
            CreateMap<BankCredential, BankCredentialInfoResponseDTO>().ReverseMap();

            CreateMap<Booking, GetAllBookingDTO>().ReverseMap();
            CreateMap<CreateBookingDTO, Booking>().ReverseMap();
            CreateMap<Booking, EditBookingDTO>().ReverseMap();
            CreateMap<Booking, BookingInfoResponseDTO>().ReverseMap();

            CreateMap<Ticket, GetAllTicketDTO>().ReverseMap();
            CreateMap<CreateTicketDTO, Ticket>().ReverseMap();
            CreateMap<Ticket, EditTicketDTO>().ReverseMap();
            CreateMap<Ticket, TicketInfoResponseDTO>().ReverseMap();

           CreateMap<Transaction, GetAllTransactionDTO>().ReverseMap();
           CreateMap<CreateTransactionDTO, Transaction>().ReverseMap();
           CreateMap<Transaction, EditTransactionDTO>().ReverseMap();
           CreateMap<Transaction, TransactionInfoResponseDTO>().ReverseMap()
;
        }
    }
}
