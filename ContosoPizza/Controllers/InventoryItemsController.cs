using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryItemsController : ControllerBase
    {
        private readonly InventoryItemService _inventoryService;

        public InventoryItemsController(InventoryItemService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: api/inventoryitems
        [HttpGet]
        public async Task<ActionResult<List<InventoryItem>>> GetAll()
        {
            var items = await _inventoryService.GetAllAsync();
            return Ok(items);
        }

        // GET: api/inventoryitems/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItem>> GetById(string id)
        {
            var item = await _inventoryService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // GET: api/inventoryitems/store/{storeId}
        [HttpGet("store/{storeId}")]
        public async Task<ActionResult<List<InventoryItem>>> GetByStoreId(string storeId)
        {
            var items = await _inventoryService.GetByStoreIdAsync(storeId);
            return Ok(items);
        }

        // POST: api/inventoryitems
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryItem item)
        {
            await _inventoryService.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/inventoryitems/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] InventoryItem item)
        {
            if (id != item.Id)
                return BadRequest("ID mismatch");

            var existing = await _inventoryService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _inventoryService.UpdateAsync(item);
            return NoContent();
        }

        // DELETE: api/inventoryitems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _inventoryService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _inventoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
