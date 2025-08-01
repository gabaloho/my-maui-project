using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogController : ControllerBase
    {
        private readonly AuditLogService _auditLogService;

        public AuditLogController(AuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _auditLogService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var log = await _auditLogService.GetByIdAsync(id);
            if (log == null) return NotFound();
            return Ok(log);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuditLog log)
        {
            var created = await _auditLogService.CreateAsync(log);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
