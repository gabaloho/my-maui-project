using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System;

namespace ContosoPizza.Models
{
    [Collection("auditLogs")]
    public class AuditLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("entityType")]
        public string EntityType { get; set; } = null!; // e.g., Order, InventoryItem

        [BsonElement("entityId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EntityId { get; set; } = null!;

        [BsonElement("action")]
        public string Action { get; set; } = null!; // e.g., Created, Updated, Deleted

        [BsonElement("performedBy")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? PerformedBy { get; set; } // Employee or Customer

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [BsonElement("details")]
        public string? Details { get; set; }
    }
}
