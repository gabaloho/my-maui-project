using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContosoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStores()
        {
            var stores = Services.ContosoService.GetStores();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public IActionResult GetStoreById(int id)
        {
            var store = Services.ContosoService.GetStoreById(id);
            if (store == null)
                return NotFound();

            return Ok(store);
        }
    }
}
