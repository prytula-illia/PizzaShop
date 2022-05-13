using PizzaApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
