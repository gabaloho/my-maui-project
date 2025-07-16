using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly StoreService _storeService;

        public StoresController(StoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stores>>> Get()
        {
            var stores = await _storeService.GetAllAsync();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stores>> Get(string id)
        {
            var store = await _storeService.GetByIdAsync(id);
            if (store == null)
                return NotFound();
            return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Stores store)
        {
            await _storeService.AddAsync(store);
            return CreatedAtAction(nameof(Get), new { id = store.Id }, store);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Stores store)
        {
            if (id != store.Id)
                return BadRequest();

            await _storeService.UpdateAsync(store);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var store = await _storeService.GetByIdAsync(id);
            if (store == null)
                return NotFound();

            await _storeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
