using Metro.Ticketing.BL.Business;
using Metro.Ticketing.Domain.RequestDTO;
using Metro.Ticketing.Domain.ResponseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro.Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
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

        [HttpPost]
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
    }
}
