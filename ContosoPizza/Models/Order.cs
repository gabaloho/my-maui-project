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
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ContosoStoreId { get; set; }
        public Stores? ContosoStore { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Pending";

        public List<OrderItem> Items { get; set; } = new();

        public decimal TotalAmount => Items.Sum(i => i.Quantity * i.Price);
    }

    public class OrderItem
    {
        public string PizzaId { get; set; }
        public Pizza? Pizza { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; } // price snapshot
    }
}
