using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizzas()
        {
            var pizzas = Services.PizzaService.GetPizzas();
            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        public IActionResult GetPizzaById(int id)
        {
            var pizza = Services.PizzaService.GetPizzaById(id);
            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }

    }


}
