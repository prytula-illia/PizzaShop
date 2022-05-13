using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.BLL.Interfaces
{
    public interface ICrud<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Add(T model);
        void Update(T model);
        void DeleteById(string modelId);
    }
}
