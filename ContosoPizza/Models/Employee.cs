using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    [Collection("employees")]
    public class Employee
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Role { get; set; } = "Staff"; // e.g., Chef, Delivery, Cashier, Manager

        public string StoreId { get; set; } = string.Empty;

        // Work schedule (optional)
        public List<WorkShift> WorkShifts { get; set; } = new();

        // Optional: Authentication info for login (hash passwords, etc.) — consider security
        // public string PasswordHash { get; set; }
    }

    public class WorkShift
    {
        public string DayOfWeek { get; set; } = string.Empty; // e.g., Monday
        public string StartTime { get; set; } = string.Empty; // "09:00"
        public string EndTime { get; set; } = string.Empty;   // "17:00"
    }
}
