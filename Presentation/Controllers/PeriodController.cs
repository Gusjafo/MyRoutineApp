using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //public class PeriodController(IPeriodService periodService) : WebApiController
    public class PeriodController(IPeriodService periodService) : ControllerBase
    {
        private readonly IPeriodService _periodService = periodService;

        // GET: <PeriodController>
        [HttpGet]
        public async Task<ActionResult<List<PeriodDTO>>> Get()
        {
            var periods = await _periodService.GetPeriodsAsync();            
            
            if (periods.Count == 0)
            {
                return NotFound();
            }            
            
            return Ok(periods);
        }

        // GET <PeriodController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeriodDTO>> Get(int id)
        {
            var periodDTO = await _periodService.GetPeriodByIdAsync(id);

            if (periodDTO == null)
            {
                return NotFound();
            }
            return Ok(periodDTO);
        }

        [HttpGet("IsActive")]
        public async Task<ActionResult<int>> GetPeriodActive(string userId)
        {
            var response = await _periodService.GetPeriodActive(userId);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        // POST <PeriodController>
        [HttpPost]
        public async Task<ActionResult> Post(PeriodDTO periodDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _periodService.CreatePeriod(periodDTO);

            if (response == null)
            {
                return NoContent();
            }
            return UnprocessableEntity(response);

        }

        // PUT api/<PeriodController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePeriod(int id, PeriodDTO periodDTO)
        {
            if (periodDTO == null || id != periodDTO.ID)
            {
                return BadRequest("Model is null or ID mismatch");
            }

            var updateModel = await _periodService.UpdatePeriod(id, periodDTO);
            if (updateModel == null)
            {
                return NotFound("Model not found");
            }
            return Ok(updateModel);
        }

        // DELETE api/<PeriodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
