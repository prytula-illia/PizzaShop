using PizzaApp.BLL.Models;

namespace PizzaApp.BLL.Interfaces
{
    public interface IIngridientService : ICrud<IngridientModel>
    {
        public void OrderMoreProducts(IngridientModel model);
    }
}
