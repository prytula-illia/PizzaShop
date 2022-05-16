using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PizzaApp.DAL.Entities
{
    public class Ingridient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
