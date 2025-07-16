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

    [Collection("deliveryzones")]
    public class DeliveryZone
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("area")]
        public GeoJsonPolygon Area { get; set; } = new GeoJsonPolygon();

        [BsonElement("storeIds")]
        public List<string> StoreIds { get; set; } = new();

        [BsonElement("deliveryFee")]
        public decimal? DeliveryFee { get; set; }  // Nullable to prevent missing field error

        [BsonElement("minimumOrderAmount")]
        public decimal? MinimumOrderAmount { get; set; }  // Nullable for same reason

        [BsonElement("deliveryTimeSlots")]
        public List<DeliveryTimeSlot> DeliveryTimeSlots { get; set; } = new();
    }
}
