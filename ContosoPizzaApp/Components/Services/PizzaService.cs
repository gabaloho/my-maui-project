using ContosoPizzaApp.Components.Models;
using System.Net.Http.Json;

namespace ContosoPizzaApp.Components.Services
{
    public class PizzaService
    {
        private readonly HttpClient _http;

        public PizzaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Pizza>> GetPizzasAsync()
        {
            var pizzas = await _http.GetFromJsonAsync<List<Pizza>>("api/pizzas");
            return pizzas ?? new List<Pizza>();
        }
    }
}
