using PizzaApp.BLL.Models;

namespace PizzaApp.BLL.Interfaces
{
    public interface IPaymentService : ICrud<PaymentModel>
    {
        public bool MakePayment(PaymentModel payment);
    }
}
