﻿namespace ContosoPizza.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; } // Snapshot of the price at order time
    }
}
