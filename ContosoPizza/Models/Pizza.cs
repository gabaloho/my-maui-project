namespace ContosoPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsGlutenFree { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }

        public int ContosoId { get; set; }
        public Contoso? Contoso { get; set; }
    }
}
