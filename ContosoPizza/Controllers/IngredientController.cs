using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientService _ingredientService;

        public IngredientController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _ingredientService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var ingredient = await _ingredientService.GetByIdAsync(id);
            if (ingredient == null) return NotFound();
            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ingredient ingredient)
        {
            var created = await _ingredientService.CreateAsync(ingredient);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Ingredient ingredient)
        {
            var updated = await _ingredientService.UpdateAsync(id, ingredient);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _ingredientService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
