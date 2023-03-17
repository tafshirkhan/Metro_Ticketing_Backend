using Metro.Ticketing.BL.Business;
using Metro.Ticketing.Domain.RequestDTO.Seat;
using Metro.Ticketing.Domain.RequestDTO.Transaction;
using Metro.Ticketing.Domain.ResponseDTO.Seat;
using Metro.Ticketing.Domain.ResponseDTO.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro.Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionBusiness _transactionBusiness;

        public TransactionController(TransactionBusiness transactionBusiness)
        {
            _transactionBusiness = transactionBusiness;
        }

        [HttpGet]
        public IEnumerable<GetAllTransactionDTO> GetAllTransactionInfo()
        {
            return _transactionBusiness.GetAllTransaction();
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionInfoResponseDTO> GetTransaction(Guid id)
        {
            if (id == null)
                return BadRequest();
            return _transactionBusiness.GetTransactionById(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeat(Guid id, EditTransactionDTO transaction)
        {
            if (id == null || id != transaction.TransactionId)
                return BadRequest();
            return Ok(_transactionBusiness.UpdateTransaction(transaction));
        }

        [HttpPost]
        public IActionResult AddTransaction(CreateTransactionDTO transaction)
        {
            _transactionBusiness.InsertTransaction(transaction);
            return Ok(transaction);
        }
    }
}
