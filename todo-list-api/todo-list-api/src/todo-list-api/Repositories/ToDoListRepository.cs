using ToDoList.Models;

namespace ToDoList.Repositories.Interfaces
{
    public class ToDoListRepository : BaseRepository<ListItem>, IToDoListRepository
    {
        public ToDoListRepository(ToDoDbContext context) : base(context) { }
    }
}
