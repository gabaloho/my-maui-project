namespace ContosoPizza.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Optional: for location-based ordering
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        // Optional: nearest or preferred Contoso outlet
        public int? PreferredStoreId { get; set; }
        public Contoso? PreferredStore { get; set; }
    }
}
