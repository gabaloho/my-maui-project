using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace ContosoPizza.Models
{
    [Collection("storeReviews")]
    public class StoreReview
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("storeId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StoreId { get; set; } = null!;

        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; } = null!;

        [BsonElement("rating")]
        public int Rating { get; set; } // 1-5

        [BsonElement("comment")]
        public string? Comment { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }


}
