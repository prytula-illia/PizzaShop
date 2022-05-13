using AutoMapper;
using PizzaApp.BLL.Interfaces;
using PizzaApp.BLL.Models;
using PizzaApp.DAL.Entities;
using PizzaApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(PaymentModel model)
        {
            var entity = _mapper.Map<PaymentModel, Payment>(model);
            _unitOfWork.Payments.Create(entity);
        }

        public bool MakePayment(PaymentModel payment)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            if(r.Next() % 2 == 0)
            {
                payment.Time = DateTime.Now;
                Add(payment);

                var pizza = _unitOfWork.Pizzas.Get(payment.PizzaId);

                foreach (var ing in pizza.IngridientsIds)
                {
                    var ingridient = _unitOfWork.Ingridients.Get(ing);
                    ingridient.Count -= 5;
                    _unitOfWork.Ingridients.Update(ingridient);
                }

                return true;
            }
            return false;
        }

        public void DeleteById(string modelId)
        {
            _unitOfWork.Payments.DeleteById(modelId);
        }

        public IEnumerable<PaymentModel> GetAll()
        {
            var entities = _unitOfWork.Payments.Get();
            return _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentModel>>(entities);
        }

        public PaymentModel GetById(string id)
        {
            var entity = _unitOfWork.Payments.Get(id);
            return _mapper.Map<Payment, PaymentModel>(entity);
        }

        public void Update(PaymentModel model)
        {
            var entity = _mapper.Map<PaymentModel, Payment>(model);
            _unitOfWork.Payments.Update(entity);
        }


    }
}
