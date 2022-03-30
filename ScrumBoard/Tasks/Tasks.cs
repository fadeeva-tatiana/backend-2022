namespace ScrumBoard.Body
{
    public class Task : TaskInterface
    {
        public Task(string title, string description, Task_priority priority)
        {
            Title = title;
            Description = description;
            Priority = priority;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public Task_priority Priority { get; set; }
    }
}