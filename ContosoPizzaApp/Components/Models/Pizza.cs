using System.Text.Json.Serialization;

namespace ContosoPizzaApp.Components.Models
{
    public class Pizza
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("isGlutenFree")]
        public bool IsGlutenFree { get; set; }

        [JsonPropertyName("isVegetarian")]
        public bool IsVegetarian { get; set; }

        [JsonPropertyName("isVegan")]
        public bool IsVegan { get; set; }
    }
}
