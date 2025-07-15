using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetPizzasAsync();
        Task<Pizza?> GetPizzaByIdAsync(int id);
        Task<Pizza> CreatePizzaAsync(Pizza pizza);
        Task<Pizza?> UpdatePizzaAsync(int id, Pizza pizza);
        Task<bool> DeletePizzaAsync(int id);
    }
}