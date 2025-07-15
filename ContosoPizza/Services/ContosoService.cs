namespace ContosoPizza.Services
{
    public class ContosoService
    {
        private static List<Models.Contoso> Stores = new()
        {

        }


        public static List<Models.Contoso> GetStores() => Stores;

        public static Models.Contoso? GetStoreById(int id) =>
            Stores.FirstOrDefault(s => s.Id == id);

    }
}
