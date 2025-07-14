namespace ContosoPizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int ContosoStoreId { get; set; }
        public Contoso? ContosoStore { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // or Confirmed, Delivered, Cancelled

        public List<OrderItem> Items { get; set; } = new();
        public decimal TotalAmount => Items.Sum(i => i.Quantity * i.Price);
    }
}
