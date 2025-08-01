using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace ContosoPizza.Models
{
    [Collection("ingredients")]
    public class Ingredient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("isAllergen")]
        public bool IsAllergen { get; set; } = false;

        [BsonElement("isVegetarian")]
        public bool IsVegetarian { get; set; } = false;

        [BsonElement("isVegan")]
        public bool IsVegan { get; set; } = false;
    }
}
