using Microsoft.AspNetCore.Mvc;
using PizzaApp.BLL.Interfaces;
using PizzaApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService _service;
        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentModel>> GetAllPayments()
        {
            return _service.GetAll().ToList();
        }

        [HttpPost]
        public ActionResult Create(PaymentModel payment)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (_service.MakePayment(payment))
                {
                    return Ok();
                }
            }
            
            return StatusCode(502);
        }
    }
}
