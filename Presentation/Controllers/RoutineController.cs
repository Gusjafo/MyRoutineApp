using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutineController(IPeriodService periodService) : ControllerBase
    {
        private readonly IPeriodService _periodService = periodService;

        [HttpGet]
        public async Task<List<PeriodDTO?>> GetPeriods()
        {
            return await _periodService.GetPeriodsAsync();
        }

    }
}
