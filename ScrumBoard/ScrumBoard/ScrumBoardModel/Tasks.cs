namespace ScrumBoard.Body
{
    public class Task : TaskInterface
    {
        public Task(string identifier, string title, string description, Task_priority priority)
        {
            ID = identifier;
            Title = title;
            Description = description;
            Priority = priority;
        }
        public string ID { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Task_priority Priority { get; set; }
    }
}
