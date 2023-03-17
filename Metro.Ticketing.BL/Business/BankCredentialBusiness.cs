using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO.BankCredential;
using Metro.Ticketing.Domain.RequestDTO.Passenger;
using Metro.Ticketing.Domain.ResponseDTO.BankCredential;
using Metro.Ticketing.Domain.ResponseDTO.Passenger;
using Metro.Ticketing.Infrastructure.IUnitOfWork;
using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.BL.Business
{
    public class BankCredentialBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankCredentialBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public BankCredentialInfoResponseDTO GetBankCredentialById(Guid bankCredId)
        {
            var bankCredential = _unitOfWork.BankCredentialRepository.Get(b => b.BankCredId == bankCredId);
            var bankCredentialDto = _mapper.Map<BankCredentialInfoResponseDTO>(bankCredential);
            return bankCredentialDto;
        }

        public IEnumerable<GetAllBankCredentialDTO> GetAllBankCredential()
        {
            var allBankCredential = _unitOfWork.BankCredentialRepository.GetAll();
            var allBankCredentialDTO = _mapper.Map<List<GetAllBankCredentialDTO>>(allBankCredential);
            return allBankCredentialDTO;
        }

        public CreateBankCredentialDTO InsertBankCredential(CreateBankCredentialDTO bankCredentialDTO)
        {
            var bankCredential = _mapper.Map<BankCredential>(bankCredentialDTO);
            _unitOfWork.BankCredentialRepository.Insert(bankCredential);
            _unitOfWork.Save();
            return bankCredentialDTO;
        }

        public bool UpdateBankCredential(EditBankCredentialDTO bankCredential)
        {
            try
            {
                var newBankCredential = _mapper.Map<BankCredential>(bankCredential);
                _unitOfWork.BankCredentialRepository.Update(newBankCredential);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteBankCredential(Guid bankCredentialId)
        {
            var bankCredential = GetBankCredentialById(bankCredentialId);
            if (bankCredential != null)
            {
                _unitOfWork.BankCredentialRepository.Delete(bankCredentialId);
                _unitOfWork.Save();
            }
        }
    }
}
