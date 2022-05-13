using MongoDB.Driver;
using PizzaApp.DAL.Entities;
using PizzaApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.DAL.Repositories
{
    public class IngridientRepository : IRepository<Ingridient>
    {
        private readonly IMongoCollection<Ingridient> _ingridients;

        public IngridientRepository(IPizzaShopDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ingridients = database.GetCollection<Ingridient>(settings.IngridientCollectionName);
        }

        public IEnumerable<Ingridient> Get()
        {
            return _ingridients.Find(x => true).ToList();
        }

        public Ingridient Get(string id)
        {
            return _ingridients.Find(x => x.Id == id).FirstOrDefault();
        }

        public Ingridient Create(Ingridient entity)
        {
            _ingridients.InsertOne(entity);
            return entity;
        }

        public void Update(Ingridient entity)
        {
            _ingridients.ReplaceOne(x => x.Id == entity.Id, entity);
        }

        public void Delete(Ingridient entity)
        {
            _ingridients.DeleteOne(x => x.Id == entity.Id);
        }

        public void DeleteById(string id)
        {
            _ingridients.DeleteOne(x => x.Id == id);
        }
    }
}
