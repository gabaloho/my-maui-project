using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ContosoPizza.Models
{
    [Collection("orderitems")]

    public class OrderItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; } // Snapshot of the price at order time
    }
}
