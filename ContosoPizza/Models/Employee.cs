using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    [Collection("employees")]
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("storeId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StoreId { get; set; } = null!;

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("role")]
        public string Role { get; set; } = null!; // e.g., Manager, Cook, Driver

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("workShifts")]
        public List<WorkShift> WorkShifts { get; set; } = new();
    }

    public class WorkShift
    {
        [BsonElement("dayOfWeek")]
        public string DayOfWeek { get; set; } = string.Empty; // e.g., Monday

        [BsonElement("startTime")]
        public string StartTime { get; set; } = string.Empty; // "09:00"

        [BsonElement("endTime")]
        public string EndTime { get; set; } = string.Empty;   // "17:00"
    }
}
