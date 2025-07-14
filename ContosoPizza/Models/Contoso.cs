namespace ContosoPizza.Models
{
    public class Contoso
    {
        public int Id { get; set; }                         
        public string Name { get; set; } = string.Empty;    
        public string Address { get; set; } = string.Empty; 
        public string City { get; set; } = string.Empty;    
        public string State { get; set; } = string.Empty;  
        public string ZipCode { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty; 
        public bool IsOpen { get; set; }                    
        public double Latitude { get; set; }              
        public double Longitude { get; set; }

        public List<Pizza> Pizzas { get; set; } = new();
    }
}
