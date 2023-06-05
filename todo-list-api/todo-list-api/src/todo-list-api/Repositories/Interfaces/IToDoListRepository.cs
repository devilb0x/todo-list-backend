using ToDoList.Models;

namespace ToDoList.Repositories.Interfaces
{
    public interface IToDoListRepository : IBaseRepository<ListItem>
    {
        // nothing here to do since CRUD is taken care of by the base interface
        // but having this leaves the possibility of adding list item specific logic later
    }
}
