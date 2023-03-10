using Metro.Ticketing.BL.Business;
using Metro.Ticketing.Domain.RequestDTO;
using Metro.Ticketing.Domain.RequestDTO.Train;
using Metro.Ticketing.Domain.ResponseDTO;
using Metro.Ticketing.Domain.ResponseDTO.Train;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro.Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly TrainBusiness _trainBusiness;

        public TrainController(TrainBusiness trainBusiness)
        {
            _trainBusiness = trainBusiness;
        }

        [HttpGet]
        public IEnumerable<GetAllTrainDTO> GetAllTrainInfo()
        {
            return _trainBusiness.GetAllTrain();
        }

        [HttpGet("{id}")]
        public ActionResult<TrainInfoResponseDTO> GetTrain(Guid id)
        {
            if (id == null)
                return BadRequest();
            return _trainBusiness.GetTrainById(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrain(Guid id, EditTrainDTO train)
        {
            if (id == null || id != train.TrainId)
                return BadRequest();
            return Ok(_trainBusiness.UpdateTrain(train));
        }

        [HttpPost]
        public IActionResult AddTrain(CreateTrainDTO train)
        {
            _trainBusiness.InsertTrain(train);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTrain(Guid id)
        {
            if (id == null)
                return BadRequest();
            else
                _trainBusiness.DeleteTrain(id);
            return Ok();
        }
    }
}
