using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    [Collection("promotions")]
    public class Promotion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("code")]
        public string Code { get; set; } = null!;

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("discountPercent")]
        public decimal? DiscountPercent { get; set; }

        [BsonElement("discountAmount")]
        public decimal? DiscountAmount { get; set; }

        [BsonElement("validFrom")]
        public DateTime ValidFrom { get; set; }

        [BsonElement("validTo")]
        public DateTime ValidTo { get; set; }

        [BsonElement("applicableStoreIds")]
        public List<string>? ApplicableStoreIds { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = true;
    }
}
