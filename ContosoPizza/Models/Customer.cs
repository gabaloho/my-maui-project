using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace ContosoPizza.Models
{
    [Collection("customers")]
    public class Customer
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string? PreferredStoreId { get; set; }

        [BsonIgnore]
        public Stores? PreferredStore { get; set; }
    }
}
