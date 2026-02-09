namespace TaskManager.Api.Models
{
    public enum TaskPriority { Low, Medium, High }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}