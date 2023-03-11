using Metro.Ticketing.BL.Business;
using Metro.Ticketing.Domain.RequestDTO.BankCredential;
using Metro.Ticketing.Domain.RequestDTO.Passenger;
using Metro.Ticketing.Domain.ResponseDTO.BankCredential;
using Metro.Ticketing.Domain.ResponseDTO.Passenger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro.Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankCredentialController : ControllerBase
    {
        private readonly BankCredentialBusiness _bankCredentialBusiness;

        public BankCredentialController(BankCredentialBusiness bankCredentialBusiness)
        {
            _bankCredentialBusiness = bankCredentialBusiness;
        }


        [HttpGet]
        public IEnumerable<GetAllBankCredentialDTO> GetAllBankCredentialInfo()
        {
            return _bankCredentialBusiness.GetAllBankCredential();
        }

        [HttpGet("{id}")]
        public ActionResult<BankCredentialInfoResponseDTO> GetBankCredential(Guid id)
        {
            if (id == null)
                return BadRequest();
            return _bankCredentialBusiness.GetBankCredentialById(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBankCredential(Guid id, EditBankCredentialDTO bankCredential)
        {
            if (id == null || id != bankCredential.BankCredId)
                return BadRequest();
            return Ok(_bankCredentialBusiness.UpdateBankCredential(bankCredential));
        }

        [HttpPost]
        public IActionResult AddBankCredential(CreateBankCredentialDTO bankCredential)
        {
            _bankCredentialBusiness.InsertBankCredential(bankCredential);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBankCredential(Guid id)
        {
            if (id == null)
                return BadRequest();
            else
                _bankCredentialBusiness.DeleteBankCredential(id);
            return Ok();
        }
    }
}
