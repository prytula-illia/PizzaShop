using AutoMapper;
using PizzaApp.BLL.Interfaces;
using PizzaApp.BLL.Models;
using PizzaApp.DAL.Entities;
using PizzaApp.DAL.Interfaces;
using System.Collections.Generic;

namespace PizzaApp.BLL.Services
{
    public class PizzaService : ICrud<PizzaModel>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public PizzaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(PizzaModel model)
        {
            var entity = _mapper.Map<PizzaModel, Pizza>(model);
            _unitOfWork.Pizzas.Create(entity);
        }

        public void DeleteById(string modelId)
        {
            _unitOfWork.Pizzas.DeleteById(modelId);
        }

        public IEnumerable<PizzaModel> GetAll()
        {
            var entities = _unitOfWork.Pizzas.Get();
            return _mapper.Map<IEnumerable<Pizza>, IEnumerable<PizzaModel>>(entities);
        }

        public PizzaModel GetById(string id)
        {
            var entity = _unitOfWork.Pizzas.Get(id);
            return _mapper.Map<Pizza, PizzaModel>(entity);
        }

        public void Update(PizzaModel model)
        {
            var entity = _mapper.Map<PizzaModel, Pizza>(model);
            _unitOfWork.Pizzas.Update(entity);
        }
    }
}
