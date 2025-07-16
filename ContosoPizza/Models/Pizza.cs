using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace ContosoPizza.Models
{
    [Collection("pizzas")]
    public class Pizza
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("price")]
        public decimal? Price { get; set; }

        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }

        [BsonElement("isGlutenFree")]
        public bool? IsGlutenFree { get; set; }

        [BsonElement("isVegetarian")]
        public bool? IsVegetarian { get; set; }

        [BsonElement("isVegan")]
        public bool? IsVegan { get; set; }

        [BsonIgnore]
        public Stores? ContosoStore { get; set; }
    }
}
