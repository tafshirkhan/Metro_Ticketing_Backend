using Metro.Ticketing.BL.Business;
using Metro.Ticketing.Domain.Entities;
using Metro.Ticketing.Domain.RequestDTO;
using Metro.Ticketing.Domain.ResponseDTO;
using MetroTicketing.System.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro.Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;
        private readonly IConfiguration _configuration;

        public UserController(UserBusiness userBusiness, IConfiguration configuration)
        {
            _userBusiness = userBusiness;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<GetAllUserDTO> GetAllUserInfo()
        {
            return _userBusiness.GetAllUser();
        }

        [HttpGet("{id}")]
        public ActionResult<UserInfoResponseDTO> GetUser(Guid id)
        {
            if (id == null)
                return BadRequest();
            return _userBusiness.GetUserById(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, EditUserDTO user)
        {
            if (id == null || id != user.UserID)
                return BadRequest();
            return Ok(_userBusiness.UpdateUser(user));
        }
        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult Adduser(CreateUserDTO user)
        {
            _userBusiness.InsertUser(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            if (id == null)
                return BadRequest();
            else
                _userBusiness.DeleteUser(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userExist = _userBusiness.GetUserByEmailPass(user.Email, user.Password);
           
            if(userExist != null)
            {
                return Ok(new JwtService(_configuration).GenerateToken(
                    userExist.UserID.ToString(),
                    userExist.Name,
                    userExist.Email,
                    userExist.Address,
                    userExist.Mobile,
                    userExist.Role
                    )
                );
            }
            return Ok("Login failed");
        }
    }
}
