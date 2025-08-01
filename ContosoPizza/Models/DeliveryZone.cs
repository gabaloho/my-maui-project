using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContosoPizza.Models
{

    public class GeoJsonPolygon
    {
        [BsonElement("type")]
        public string Type { get; set; } = "Polygon";

        [BsonElement("coordinates")]
        public List<List<double[]>> Coordinates { get; set; } = new();
    }

    public class DeliveryTimeSlot
    {
        [BsonElement("dayOfWeek")]
        public string DayOfWeek { get; set; } = string.Empty;

        [BsonElement("startTime")]
        public string StartTime { get; set; } = string.Empty;

        [BsonElement("endTime")]
        public string EndTime { get; set; } = string.Empty;
    }

    [Collection("deliveryZones")]
    public class DeliveryZone
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("storeId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StoreId { get; set; } = null!;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        // Polygon coordinates for the delivery area (GeoJSON)
        [BsonElement("area")]
        public List<List<double>>? Area { get; set; }

        // Or, if you use zip codes:
        [BsonElement("zipCodes")]
        public List<string>? ZipCodes { get; set; }

        [BsonElement("deliveryFee")]
        public decimal DeliveryFee { get; set; }

        [BsonElement("minimumOrderAmount")]
        public decimal MinimumOrderAmount { get; set; }
        [BsonElement("deliveryTimeSlots")]
        public List<DeliveryTimeSlot> DeliveryTimeSlots { get; set; } = new();
    }
}
