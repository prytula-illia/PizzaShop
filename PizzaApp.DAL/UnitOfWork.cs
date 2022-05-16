using PizzaApp.DAL.Entities;
using PizzaApp.DAL.Interfaces;
using PizzaApp.DAL.Repositories;

namespace PizzaApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        IPizzaShopDbSettings _settings;

        public UnitOfWork(IPizzaShopDbSettings settings)
        {
            _settings = settings;
        }

        private IngridientRepository ingridientRepository;
        public IRepository<Ingridient> Ingridients
        {
            get
            {
                if (ingridientRepository is null)
                    ingridientRepository = new IngridientRepository(_settings);
                return ingridientRepository;
            }
        }

        private PizzaRepository pizzaRepository;
        public IRepository<Pizza> Pizzas
        {
            get
            {
                if (pizzaRepository is null)
                    pizzaRepository = new PizzaRepository(_settings);
                return pizzaRepository;
            }
        }

        private PaymentRepository paymentRepository;
        public IRepository<Payment> Payments
        {
            get
            {
                if (paymentRepository is null)
                    paymentRepository = new PaymentRepository(_settings);
                return paymentRepository;
            }
        }
    }
}
