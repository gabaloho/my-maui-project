using System.Security.Cryptography.X509Certificates;
using MongoDB.Bson;
using MongoDB.Driver;
using ContosoPizza.Services;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly ContosoPizzaDbContext _context;
        public PizzaService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public void AddPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }

        public void GetPizzasAsync(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }


        public Pizza GetPizzaByIdAsync(int id)
        {
            var pizza = _context.Pizzas.Find(id);
            if (pizza == null)
            {
                throw new KeyNotFoundException($"Pizza with ID {id} not found.");
            }
            return pizza;
        }

        public void CreatePizzaAsync(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }

        public void UpdatePizzaAsync(int id, Pizza pizza)
        {
            var existingPizza = _context.Pizzas.Find(id);
            if (existingPizza == null)
            {
                throw new KeyNotFoundException($"Pizza with ID {id} not found.");
            }

            existingPizza.Name = pizza.Name;
            existingPizza.Description = pizza.Description;
            existingPizza.Price = pizza.Price;
            existingPizza.ImageUrl = pizza.ImageUrl;
            existingPizza.IsGlutenFree = pizza.IsGlutenFree;
            existingPizza.IsVegetarian = pizza.IsVegetarian;
            existingPizza.IsVegan = pizza.IsVegan;

            _context.SaveChanges();
        }

        public void DeletePizzaAsync(int id)
        {
            var pizza = _context.Pizzas.Find(id);
            if (pizza == null)
            {
                throw new KeyNotFoundException($"Pizza with ID {id} not found.");
            }

            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
        }


        public List<Pizza> GetPizzas()
        {
            var pizzas = _context.Pizzas.ToList();
            if (pizzas == null || !pizzas.Any())
            {
                throw new InvalidOperationException("No pizzas found.");
            }
            return pizzas;
        }



        public Pizza GetPizzaById(int id)
        {
            var pizza = _context.Pizzas.Find(id);
            if (pizza == null)
            {
                throw new KeyNotFoundException($"Pizza with ID {id} not found.");
            }
            return pizza;
        }

        public Task<List<Pizza>> GetPizzasAsync()
        {
            throw new NotImplementedException();
        }

        Task<Pizza?> IPizzaService.GetPizzaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Pizza> IPizzaService.CreatePizzaAsync(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        Task<Pizza?> IPizzaService.UpdatePizzaAsync(int id, Pizza pizza)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPizzaService.DeletePizzaAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

