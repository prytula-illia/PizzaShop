using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.BLL.Models
{
    public class PaymentModel
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public DateTime Time { get; set; }
        public string PizzaId { get; set; }
    }
}
