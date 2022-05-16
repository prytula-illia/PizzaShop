using PizzaApp.DAL.Entities;

namespace PizzaApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Ingridient> Ingridients { get; }
        public IRepository<Pizza> Pizzas { get; }
        public IRepository<Payment> Payments { get; }
    }
}
