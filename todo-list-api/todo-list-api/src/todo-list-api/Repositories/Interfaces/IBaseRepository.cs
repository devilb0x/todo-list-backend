using ToDoList.Models;

namespace ToDoList.Repositories.Interfaces
{
    public interface IBaseRepository<T> : IDisposable 
        where T : EntityBase
    {
        public T? Get(int id);
        public List<T> GetAll();
        public void Add(T item);
        public void Delete(T item);
        public void Update(T item);

        public int Save();
    }
}
