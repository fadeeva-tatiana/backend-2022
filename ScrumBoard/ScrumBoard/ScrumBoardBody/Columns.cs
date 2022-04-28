namespace ScrumBoard.Body
{
    public class Column : ColumnInterface
    {
        public string Title { get; set; }
        public string ID { get; }

        public Column(string identifier, string title)
        {
            ID = identifier;
            Title = title;
            _tasks = new();
        }
        public TaskInterface? Find_task_by_title(string title)
        {
            return _tasks.Find(task => task.Title == title);
        }

        public void Delete_task_by_title(string title)
        {
            _tasks.RemoveAll(task => task.Title == title);
        }

        public void Add_task(TaskInterface task)
        {
            _tasks.Add(task);
        }

        public IReadOnlyCollection<TaskInterface> Find_tasks()
        {
            return _tasks;
        }

        private List<TaskInterface> _tasks;
    }
}
