namespace ScrumBoard.Body
{
    public class Task : ITask
    {
        public Task(string title, string description, Task_priority priority)
        {
            ID = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            Priority = priority;
        }
        public string? ID { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Task_priority Priority { get; set; }
    }
}