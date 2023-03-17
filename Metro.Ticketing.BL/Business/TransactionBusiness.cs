using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO.Booking;
using Metro.Ticketing.Domain.RequestDTO.Transaction;
using Metro.Ticketing.Domain.ResponseDTO.Booking;
using Metro.Ticketing.Domain.ResponseDTO.Transaction;
using Metro.Ticketing.Infrastructure.IUnitOfWork;
using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.BL.Business
{
    public class TransactionBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<GetAllTransactionDTO> GetAllTransaction()
        {
            var allTransaction = _unitOfWork.TransactionRepository.GetAll();
            var allTransactionDTO = _mapper.Map<List<GetAllTransactionDTO>>(allTransaction);
            return allTransactionDTO;
        }

        public TransactionInfoResponseDTO GetTransactionById(Guid transactionId)
        {
            var transaction = _unitOfWork.TransactionRepository.Get(t => t.TransactionId == transactionId);
            var transactionIdDto = _mapper.Map<TransactionInfoResponseDTO>(transactionId);
            return transactionIdDto;
        }

        public CreateTransactionDTO InsertTransaction(CreateTransactionDTO transactionDTO)
        {
            var transaction = _mapper.Map<Transaction>(transactionDTO);
            _unitOfWork.TransactionRepository.Insert(transaction);
            _unitOfWork.Save();
            return transactionDTO;
        }

        public bool UpdateTransaction(EditTransactionDTO transaction)
        {
            try
            {
                var newTransaction = _mapper.Map<Transaction>(transaction);
                _unitOfWork.TransactionRepository.Update(newTransaction);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
