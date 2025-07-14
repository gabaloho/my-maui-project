namespace ContosoPizza.Services
{
    public class ContosoService
    {
        private static List<Models.Contoso> Stores = new()
        {
            new Models.Contoso
            {
                Id = 1,
                Name = "Contoso Pizza - Brussels",
                Address = "123 Rue de Pizza",
                City = "Brussels",
                State = "Brussels Capital",
                ZipCode = "1000",
                PhoneNumber = "+32 2 123 4567",
                IsOpen = true,
                Latitude = 50.8503,
                Longitude = 4.3517
            },
            new Models.Contoso
            {
                Id = 2,
                Name = "Contoso Pizza - Antwerp",
                Address = "456 Antwerpsestraat",
                City = "Antwerp",
                State = "Flanders",
                ZipCode = "2000",
                PhoneNumber = "+32 3 765 4321",
                IsOpen = true,
                Latitude = 51.2194,
                Longitude = 4.4025
            }
        };

        public static List<Models.Contoso> GetStores() => Stores;

        public static Models.Contoso? GetStoreById(int id) =>
            Stores.FirstOrDefault(s => s.Id == id);
    
    }
}
