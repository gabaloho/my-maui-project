namespace ContosoPizza.Services
{
    public static class CustomerService
    {
        private static List<Models.Customer> Customers = new()
        {
            new Models.Customer
            {
                Id = 1,
                FullName = "Alice Johnson",
                Email = "alice@example.com",
                PhoneNumber = "+32 123456789",
                City = "Brussels",
                PreferredStoreId = 1
            },
            new Models.Customer
            {
                Id = 2,
                FullName = "Bob de Vries",
                Email = "bob@example.com",
                PhoneNumber = "+32 987654321",
                City = "Antwerp",
                PreferredStoreId = 2
            }
        };

        public static List<Models.Customer> GetCustomers() => Customers;

        public static Models.Customer? GetById(int id) =>
            Customers.FirstOrDefault(c => c.Id == id);
    }
}
