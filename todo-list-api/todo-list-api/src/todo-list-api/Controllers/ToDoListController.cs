using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Models.Dtos;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Controllers
{
    [AllowAnonymous]
    [Route("todolist")]
    public class ToDoListController : Controller
    {
        private IToDoListRepository todoRepo;

        public ToDoListController(
            ToDoDbContext context)
        {
            todoRepo = new ToDoListRepository(context);
        }

        [HttpGet("get")]
        public IActionResult GetAll()
        {
            var listItems = todoRepo.GetAll();
            return Ok(listItems);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var listItem = todoRepo.Get(id);

            if (listItem == null)
            {
                return BadRequest(new { error = $"List item not found for ID {id}" });
            }

            return Ok(listItem);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] ListItemDto itemDto)
        {
            if (string.IsNullOrWhiteSpace(itemDto.Description))
            {
                return BadRequest(new { error = "Description cannot be null" });
            }

            var listItem = new ListItem(
                itemDto.Description, 
                !string.IsNullOrWhiteSpace(itemDto.DateDue) ? DateTime.Parse(itemDto.DateDue) : null);

            todoRepo.Add(listItem);
            todoRepo.Save();

            return Ok(listItem);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] ListItemDto itemDto)
        {
            if (string.IsNullOrWhiteSpace(itemDto.Description))
            {
                return BadRequest(new { error = "Description cannot be empty" });
            }

            var listItem = todoRepo.Get(itemDto.Id);

            if (listItem == null)
            {
                return BadRequest(new { error = $"List item not found for ID {itemDto.Id}" });
            }

            listItem.Description = itemDto.Description;
            listItem.DateCompleted = itemDto.Completed ? DateTime.UtcNow : null;
            listItem.DateDue = !string.IsNullOrWhiteSpace(itemDto.DateDue) ? DateTime.Parse(itemDto.DateDue) : null;

            todoRepo.Save();

            return Ok(listItem);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var listItem = todoRepo.Get(id);

            if (listItem == null)
            {
                return BadRequest(new { error = $"List item not found for ID {id}" });
            }

            todoRepo.Delete(listItem);
            todoRepo.Save();

            return Ok(listItem);
        }

        protected override void Dispose(bool disposing)
        {
            todoRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}
