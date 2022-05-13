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
    public class IngridientService : IIngridientService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public IngridientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(IngridientModel model)
        {
            var entity = _mapper.Map<IngridientModel, Ingridient>(model);
            _unitOfWork.Ingridients.Create(entity);
        }

        public void DeleteById(string modelId)
        {
            _unitOfWork.Ingridients.DeleteById(modelId);
        }

        public IEnumerable<IngridientModel> GetAll()
        {
            var entities = _unitOfWork.Ingridients.Get();
            return _mapper.Map<IEnumerable<Ingridient>, IEnumerable<IngridientModel>>(entities);
        }

        public IngridientModel GetById(string id)
        {
            var entity = _unitOfWork.Ingridients.Get(id);
            return _mapper.Map<Ingridient, IngridientModel>(entity);
        }

        public void Update(IngridientModel model)
        {
            var entity = _mapper.Map<IngridientModel, Ingridient>(model);
            _unitOfWork.Ingridients.Update(entity);
        }

        public void OrderMoreProducts(IngridientModel model)
        {
            model.Count += 100;
            Update(model);
        }
    }
}
