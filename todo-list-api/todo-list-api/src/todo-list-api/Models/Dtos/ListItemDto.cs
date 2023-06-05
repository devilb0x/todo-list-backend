namespace ToDoList.Models.Dtos
{
    public class ListItemDto
    {
        public ListItemDto() { }

        public int Id { get; set; }
        public string? Description { get; set; }
        public string? DateDue { get; set; }
        public bool Completed { get; set; }
    }
}
