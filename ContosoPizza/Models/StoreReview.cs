using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace ContosoPizza.Models
{
    [Collection("reviews")]
    public class StoreReview
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string StoreId { get; set; } 

        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; } 

        public int Rating { get; set; } // 1-5 stars
        public string Comment { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
    }

}
