using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly PromotionService _promotionService;

        public PromotionController(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _promotionService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var promo = await _promotionService.GetByIdAsync(id);
            if (promo == null) return NotFound();
            return Ok(promo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Promotion promo)
        {
            var created = await _promotionService.CreateAsync(promo);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Promotion promo)
        {
            var updated = await _promotionService.UpdateAsync(id, promo);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _promotionService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
