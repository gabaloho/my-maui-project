using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Models
{
    [Collection("orders")]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CustomerId { get; set; }
        [BsonIgnore]
        public Customer? Customer { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? StoreId { get; set; }
        [BsonIgnore]
        public Stores? Store { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Pending";

        public List<OrderItem> Items { get; set; } = new();

        public decimal TotalAmount => Items.Sum(i => i.Quantity * i.PriceSnapshot);
    }

    public class OrderItem
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? PizzaId { get; set; }
        [BsonIgnore]
        public Pizza? Pizza { get; set; }

        public int Quantity { get; set; }

        public decimal PriceSnapshot { get; set; } // price at order time
    }
}
