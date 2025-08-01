using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class IngredientService
    {
        private readonly ContosoPizzaDbContext _context;

        public IngredientService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ingredient>> GetAllAsync() =>
            await _context.Ingredients.ToListAsync();

        public async Task<Ingredient?> GetByIdAsync(string id) =>
            await _context.Ingredients.FindAsync(id);

        public async Task<Ingredient> CreateAsync(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<bool> UpdateAsync(string id, Ingredient updated)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient is null) return false;

            ingredient.Name = updated.Name;
            ingredient.IsAllergen = updated.IsAllergen;
            ingredient.IsVegetarian = updated.IsVegetarian;
            ingredient.IsVegan = updated.IsVegan;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient is null) return false;

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
