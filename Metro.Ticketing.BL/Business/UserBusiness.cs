using AutoMapper;
using Metro.Ticketing.Domain.RequestDTO;
using Metro.Ticketing.Domain.ResponseDTO;
using Metro.Ticketing.Infrastructure.IUnitOfWork;
using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.BL.Business
{
    public class UserBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public List<User> GetByUserId(Guid userId)
        //{
        //    return _unitOfWork.UserRepository.GetAll(expression: u => u.UserId == userId)?.ToList();
        //}

        public UserInfoResponseDTO GetUserById(Guid userId)
        {
            var user = _unitOfWork.UserRepository.Get(u => u.UserId == userId);
           
            var userDto = _mapper.Map<UserInfoResponseDTO>(user);
            return userDto;
        }

        public IEnumerable<GetAllUserDTO> GetAllUser()
        {
            var allUser = _unitOfWork.UserRepository.GetAll();
            var allUserDTO = _mapper.Map<List<GetAllUserDTO>>(allUser);
            return allUserDTO;
        }

        public void InsertUser(CreateUserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();
        }

        public bool UpdateUser(EditUserDTO user)
        {
            try
            {
                var newUser = _mapper.Map<User>(user);
                _unitOfWork.UserRepository.Update(newUser);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteUser(Guid userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                _unitOfWork.UserRepository.Delete(userId);
                _unitOfWork.Save();
            }
        }

        public UserInfoResponseDTO GetUserByEmailPass(string email, string pass)
        {
            var user = _unitOfWork.UserRepository.Get(u => u.Email == email && u.Password == pass);
            var userDto = _mapper.Map<UserInfoResponseDTO>(user);
            return userDto;

        }

        public UserInfoResponseDTO GetUserByEmail(string email)
        {
            var user = _unitOfWork.UserRepository.Get(u => u.Email == email);
            var userDto = _mapper.Map<UserInfoResponseDTO>(user);
            return userDto;

        }

    }
}
