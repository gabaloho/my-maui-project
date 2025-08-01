using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly SessionService _sessionService;

        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _sessionService.GetAllAsync());

        [HttpGet("{token}")]
        public async Task<IActionResult> GetByToken(string token)
        {
            var session = await _sessionService.GetByTokenAsync(token);
            if (session == null) return NotFound();
            return Ok(session);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Session session)
        {
            var created = await _sessionService.CreateAsync(session);
            return CreatedAtAction(nameof(GetByToken), new { token = created.Token }, created);
        }

        [HttpDelete("{token}")]
        public async Task<IActionResult> Delete(string token)
        {
            var deleted = await _sessionService.DeleteAsync(token);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
