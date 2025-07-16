using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    public class Address
    {
        [BsonElement("street")]
        public string? Street { get; set; }

        [BsonElement("city")]
        public string? City { get; set; }

        [BsonElement("postalCode")]
        public string? PostalCode { get; set; }
    }

    public class OpeningHours
    {
        [BsonElement("dayOfWeek")]
        public string? DayOfWeek { get; set; }

        [BsonElement("openTime")]
        public string? OpenTime { get; set; }

        [BsonElement("closeTime")]
        public string? CloseTime { get; set; }
    }

    public class GeoJsonPoint
    {
        [BsonElement("type")]
        public string? Type { get; set; }

        [BsonElement("coordinates")]
        public double[]? Coordinates { get; set; }
    }

    [Collection("stores")]
    public class Stores
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("arrondissement")]
        public string? Arrondissement { get; set; }

        [BsonElement("province")]
        public string? Province { get; set; }

        [BsonElement("address")]
        public Address? Address { get; set; }

        [BsonElement("weeklyHours")]
        public List<OpeningHours>? WeeklyHours { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("isOpen")]
        public bool? IsOpen { get; set; }

        [BsonElement("location")]
        public GeoJsonPoint? Location { get; set; }

        [BsonElement("pizzas")]
        public List<Pizza>? Pizzas { get; set; }
    }
}
