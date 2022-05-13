using PizzaApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.BLL.Interfaces
{
    public interface IPaymentService : ICrud<PaymentModel>
    {
        public bool MakePayment(PaymentModel payment);
    }
}
