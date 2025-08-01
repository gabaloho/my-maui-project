using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System;

namespace ContosoPizza.Models
{
    [Collection("payments")]
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("orderId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; } = null!;

        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; } = null!;

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("paymentMethod")]
        public string PaymentMethod { get; set; } = null!; // e.g., CreditCard, Cash

        [BsonElement("status")]
        public string Status { get; set; } = "Pending"; // Pending, Completed, Failed, Refunded

        [BsonElement("transactionDate")]
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        [BsonElement("receiptNumber")]
        public string? ReceiptNumber { get; set; }

        [BsonElement("gatewayTransactionId")]
        public string? GatewayTransactionId { get; set; }

        [BsonElement("refundAmount")]
        public decimal? RefundAmount { get; set; }

        [BsonElement("refundDate")]
        public DateTime? RefundDate { get; set; }

        [BsonElement("refundStatus")]
        public string? RefundStatus { get; set; }

        [BsonElement("notes")]
        public string? Notes { get; set; }
    }

}
