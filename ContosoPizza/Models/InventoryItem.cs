using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System;

namespace ContosoPizza.Models
{
    [Collection("inventoryitems")]
    public class InventoryItem
    {
        // Maps the MongoDB _id field
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("UnitOfMeasure")]
        public string UnitOfMeasure { get; set; } = "kg";

        [BsonElement("QuantityOnHand")]
        public decimal QuantityOnHand { get; set; }

        [BsonElement("ReorderThreshold")]
        public decimal ReorderThreshold { get; set; } = 0;

        [BsonElement("SupplierName")]
        public string SupplierName { get; set; } = string.Empty;

        [BsonElement("ExpirationDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)] // Ensure UTC date handling
        public DateTime? ExpirationDate { get; set; }

        [BsonElement("StoreId")]
        public string StoreId { get; set; } = string.Empty;
    }
}
