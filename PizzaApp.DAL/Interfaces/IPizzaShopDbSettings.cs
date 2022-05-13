using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.DAL.Interfaces
{
    public interface IPizzaShopDbSettings
    {
        string IngridientCollectionName { get; set; }
        string PaymentCollectionName { get; set; }
        string PizzaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
