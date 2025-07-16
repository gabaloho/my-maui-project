using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        private readonly ContosoPizzaDbContext _context;

        public PizzasController(ContosoPizzaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> Get() => await _context.Pizzas.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> Get(string id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            return pizza is null ? NotFound() : pizza;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Pizza pizza)
        {
            if (id != pizza.Id) return BadRequest();
            _context.Entry(pizza).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza is null) return NotFound();
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }


}
