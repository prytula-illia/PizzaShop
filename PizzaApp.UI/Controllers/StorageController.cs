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
    public class StorageController : ControllerBase
    {
        IIngridientService _service;
        public StorageController(IIngridientService service)
        {
            _service = service;
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<IngridientModel> GetProduct(string id)
        {
            return _service.GetById(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<IngridientModel>> GetAllProducts()
        {
            return _service.GetAll().ToList();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult OrderNewProducts(string id)
        {
            var product = _service.GetById(id);

            if (product == null)
            {
                return StatusCode(500);
            }

            _service.OrderMoreProducts(product);

            return Ok();
        }
    }
}
