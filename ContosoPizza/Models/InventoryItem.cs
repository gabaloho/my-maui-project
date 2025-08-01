using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System;

namespace ContosoPizza.Models
{
    [Collection("inventoryItems")]
    public class InventoryItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("storeId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StoreId { get; set; } = null!;

        // Can be PizzaId or IngredientId depending on your inventory tracking
        [BsonElement("itemId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ItemId { get; set; } = null!;

        [BsonElement("itemType")]
        public string ItemType { get; set; } = "Pizza"; // or "Ingredient"

        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("upplierName")]
        public string SupplierName { get; set; } = string.Empty;

        [BsonElement("ExpirationDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)] // Ensure UTC date handling
        public DateTime? ExpirationDate { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("UnitOfMeasure")]
        public string UnitOfMeasure { get; set; } = "kg";

        [BsonElement("QuantityOnHand")]
        public decimal QuantityOnHand { get; set; }

        [BsonElement("ReorderThreshold")]
        public decimal ReorderThreshold { get; set; } = 0;

        [BsonElement("lastUpdated")]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        [BsonIgnore]
        public Pizza? Pizza { get; set; }
        // Optionally, add Ingredient navigation if you have an Ingredient model
    }
}
