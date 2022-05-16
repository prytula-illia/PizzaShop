using PizzaApp.DAL.Interfaces;

namespace PizzaApp.DAL
{
    public class PizzaShopDbSettings : IPizzaShopDbSettings
    {
        public string IngridientCollectionName { get; set; }
        public string PaymentCollectionName { get; set; }
        public string PizzaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
