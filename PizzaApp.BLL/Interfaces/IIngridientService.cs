using PizzaApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.BLL.Interfaces
{
    public interface IIngridientService : ICrud<IngridientModel>
    {
        public void OrderMoreProducts(IngridientModel model);
    }
}
