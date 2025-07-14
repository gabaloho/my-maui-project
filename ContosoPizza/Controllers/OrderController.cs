using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/order
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = OrderService.GetOrders();
            return Ok(orders);
        }

        // GET: api/order/1
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = OrderService.GetById(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (order == null || order.Items.Count == 0)
                return BadRequest("Invalid order");

            OrderService.AddOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }
    }
}
