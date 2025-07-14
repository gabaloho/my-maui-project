using System.Security.Cryptography.X509Certificates;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        public static List<Models.Pizza> GetPizzas()
        {
            return new List<Models.Pizza>
            {
                new Models.Pizza
                {
                    Id = 1,
                    Name = "Margherita",
                    Description = "Classic pizza with tomato sauce, mozzarella cheese, and fresh basil.",
                    Price = 8.99m,
                    ImageUrl = "https://example.com/margherita.jpg",
                    IsGlutenFree = false,
                    IsVegetarian = true,
                    IsVegan = false
                },
                new Models.Pizza
                {
                    Id = 2,
                    Name = "Pepperoni",
                    Description = "Spicy pepperoni slices with mozzarella cheese and tomato sauce.",
                    Price = 9.99m,
                    ImageUrl = "https://example.com/pepperoni.jpg",
                    IsGlutenFree = false,
                    IsVegetarian = false,
                    IsVegan = false
                },

                new Models.Pizza
                {
                    Id = 3,
                    Name = "BBQ Chicken",
                    Description = "Grilled chicken, BBQ sauce, red onions, and cilantro.",
                    Price = 10.99m,
                    ImageUrl= "https://example.com/bbqchicken.jpg",
                    IsGlutenFree = false,
                    IsVegetarian = false,
                    IsVegan = false
                }
            };
        }

        public static Models.Pizza? GetPizzaById(int id)
        {
            var pizzas = GetPizzas();
            return pizzas.FirstOrDefault(p => p.Id == id);
        }
    }
}

