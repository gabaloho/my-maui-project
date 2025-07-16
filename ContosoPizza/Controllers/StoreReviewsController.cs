using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreReviewController : ControllerBase
    {
        private readonly StoreReviewService _storeReviewService;

        public StoreReviewController(StoreReviewService storeReviewService)
        {
            _storeReviewService = storeReviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _storeReviewService.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet("store/{storeId}")]
        public async Task<IActionResult> GetByStoreId(string storeId)
        {
            var reviews = await _storeReviewService.GetByStoreIdAsync(storeId);
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var review = await _storeReviewService.GetByIdAsync(id);
            if (review == null) return NotFound();
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StoreReview review)
        {
            var created = await _storeReviewService.CreateAsync(review);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, StoreReview review)
        {
            var updated = await _storeReviewService.UpdateAsync(id, review);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _storeReviewService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
