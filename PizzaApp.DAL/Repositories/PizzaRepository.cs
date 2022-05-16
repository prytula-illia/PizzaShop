using MongoDB.Driver;
using PizzaApp.DAL.Entities;
using PizzaApp.DAL.Interfaces;
using System.Collections.Generic;

namespace PizzaApp.DAL.Repositories
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private readonly IMongoCollection<Pizza> _pizza;

        public PizzaRepository(IPizzaShopDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pizza = database.GetCollection<Pizza>(settings.PizzaCollectionName);
        }

        public IEnumerable<Pizza> Get()
        {
            var pizzas = _pizza.Find(x => true);
            return pizzas.ToEnumerable<Pizza>();
        }

        public Pizza Get(string id)
        {
            return _pizza.Find(x => x.Id == id).FirstOrDefault();
        }

        public Pizza Create(Pizza entity)
        {
            _pizza.InsertOne(entity);
            return entity;
        }

        public void Update(Pizza entity)
        {
            _pizza.ReplaceOne(x => x.Id == entity.Id, entity);
        }

        public void Delete(Pizza entity)
        {
            _pizza.DeleteOne(x => x.Id == entity.Id);
        }

        public void DeleteById(string id)
        {
            _pizza.DeleteOne(x => x.Id == id);
        }
    }
}
