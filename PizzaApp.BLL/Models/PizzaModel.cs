using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.BLL.Models
{
    public class PizzaModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<string> IngridientsIds { get; set; }
    }
}
