namespace ToDoList.Models
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }

        public EntityBase() { }

        protected EntityBase(int id)
        {
            Id = id;
        }
    }
}
