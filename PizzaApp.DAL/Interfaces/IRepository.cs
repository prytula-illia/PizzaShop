using System.Collections.Generic;

namespace PizzaApp.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> Get();

        public T Get(string id);

        public T Create(T ingridient);

        public void Update(T entity);

        public void Delete(T entity);

        public void DeleteById(string id);
    }
}
