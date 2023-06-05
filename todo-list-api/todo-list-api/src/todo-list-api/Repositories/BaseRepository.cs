using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> 
        where T : EntityBase  
    {
        protected ToDoDbContext Context;

        private bool disposed = false;

        public BaseRepository(ToDoDbContext context)
        {
            Context = context;
        }

        public T? Get(int id)
        {
            return Context.Set<T>().AsQueryable().SingleOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Add(T item)
        {
            Context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            Context.Set<T>().Remove(item);
        }

        public void Update(T item)
        {
            Context.Set<T>().Update(item);
        }
        public int Save()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
