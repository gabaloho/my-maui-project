using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryZoneController : ControllerBase
    {
        private readonly DeliveryZoneService _deliveryZoneService;

        public DeliveryZoneController(DeliveryZoneService deliveryZoneService)
        {
            _deliveryZoneService = deliveryZoneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var zones = await _deliveryZoneService.GetAllAsync();
            return Ok(zones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var zone = await _deliveryZoneService.GetByIdAsync(id);
            if (zone == null) return NotFound();
            return Ok(zone);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeliveryZone zone)
        {
            var created = await _deliveryZoneService.CreateAsync(zone);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, DeliveryZone zone)
        {
            var updated = await _deliveryZoneService.UpdateAsync(id, zone);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _deliveryZoneService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
