namespace ContosoPizza.Services
{
    public static class OrderService
    {
        private static List<Models.Order> Orders = new();

        public static List<Models.Order> GetOrders() => Orders;

        public static Models.Order? GetById(int id) =>
            Orders.FirstOrDefault(o => o.Id == id);

        public static void AddOrder(Models.Order order)
        {
            order.Id = Orders.Count + 1;
            order.OrderDate = DateTime.UtcNow;
            Orders.Add(order);
        }
    }
}
