using MongoDB.Driver;
using PizzaApp.DAL.Entities;
using PizzaApp.DAL.Interfaces;
using System.Collections.Generic;

namespace PizzaApp.DAL.Repositories
{
    public class PaymentRepository :IRepository<Payment>
    {
        private readonly IMongoCollection<Payment> _payments;

        public PaymentRepository(IPizzaShopDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _payments = database.GetCollection<Payment>(settings.PaymentCollectionName);
        }

        public IEnumerable<Payment> Get()
        {
            return _payments.Find(x => true).ToList();
        }

        public Payment Get(string id)
        {
            return _payments.Find(x => x.Id == id).FirstOrDefault();
        }

        public Payment Create(Payment entity)
        {
            _payments.InsertOne(entity);
            return entity;
        }

        public void Update(Payment entity)
        {
            _payments.ReplaceOne(x => x.Id == entity.Id, entity);
        }

        public void Delete(Payment entity)
        {
            _payments.DeleteOne(x => x.Id == entity.Id);
        }

        public void DeleteById(string id)
        {
            _payments.DeleteOne(x => x.Id == id);
        }
    }
}
