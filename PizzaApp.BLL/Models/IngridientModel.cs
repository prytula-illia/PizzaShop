using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.BLL.Models
{
    public class IngridientModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
