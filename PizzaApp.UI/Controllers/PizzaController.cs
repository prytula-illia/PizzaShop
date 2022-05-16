using Microsoft.AspNetCore.Mvc;
using PizzaApp.BLL.Interfaces;
using PizzaApp.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        ICrud<PizzaModel> _service;
        public PizzaController(ICrud<PizzaModel> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<PizzaModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        [HttpGet("{id:length(24)}", Name = "GetPizza")]
        public ActionResult<PizzaModel> Get(string id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public ActionResult<PizzaModel> Create(PizzaModel pizza)
        {
            _service.Add(pizza);
            return Ok();
        }
    }
}
