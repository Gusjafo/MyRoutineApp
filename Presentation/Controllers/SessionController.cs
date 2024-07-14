using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController(ISessionService sessionService) : ControllerBase
    {
        private readonly ISessionService _sessionService = sessionService;

        [HttpGet]
        public async Task<ActionResult<List<SessionDTO>?>> GetSessions()
        {
            var sessions =  await _sessionService.GetAllSessionsAsync();

            if (sessions == null)
            {
                return NoContent();
            }

            return Ok(sessions);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<SessionDTO?>> GetSessionById(int id)
        {
            var response = await _sessionService.GetSessionByIdAsync(id);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(SessionDTO sessionDTO)
        {
            var response = await _sessionService.SetSessionAsync(sessionDTO);

            if (response == null)
            {
                return Created();
            }
            return UnprocessableEntity(response);
        }
    }
}
