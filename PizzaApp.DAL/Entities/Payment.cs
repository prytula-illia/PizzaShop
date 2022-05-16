using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PizzaApp.DAL.Entities
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public decimal Price { get; set; }
        public DateTime Time { get; set; }
        public string PizzaId { get; set; }
    }
}
