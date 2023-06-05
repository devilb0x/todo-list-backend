namespace ToDoList.Models
{
    public class ListItem : EntityBase
    {
        public ListItem(string description, DateTime? dateDue)
        {
            Description = description;
            DateDue = dateDue;
            DateCreated = DateTime.UtcNow;
        }

        public string Description { get; set; }

        public DateTime? DateDue { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateCompleted { get; set; }
    }
}
