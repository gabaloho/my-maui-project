using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    [Collection("customers")]
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("fullName")]
        public string FullName { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [BsonElement("address")]
        public string Address { get; set; } = null!;

        [BsonElement("city")]
        public string City { get; set; } = null!;

        [BsonElement("zipCode")]
        public string ZipCode { get; set; } = null!;

        [BsonElement("preferredStoreId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? PreferredStoreId { get; set; }

        // Optional: Order history (list of order IDs)
        [BsonElement("orderIds")]
        public List<string>? OrderIds { get; set; }

        // Optional: Loyalty points
        [BsonElement("loyaltyPoints")]
        public int LoyaltyPoints { get; set; } = 0;

        [BsonIgnore]
        public Stores? PreferredStore { get; set; }
    }
}
