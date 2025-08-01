using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System;

namespace ContosoPizza.Models
{
    [Collection("notifications")]
    public class Notification
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("recipientId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RecipientId { get; set; } = null!; // Customer or Employee

        [BsonElement("message")]
        public string Message { get; set; } = null!;

        [BsonElement("type")]
        public string Type { get; set; } = "Info"; // Info, OrderUpdate, Promo, etc.

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("isRead")]
        public bool IsRead { get; set; } = false;
    }
}
