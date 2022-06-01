namespace ScrumBoard.Body
{
    public class Column : IColumn
    {
        private List<ITask> _tasks;

        public string Title { get; set; }
        public string ID { get; set; }

        public Column(string title)
        {
            ID = Guid.NewGuid().ToString();
            Title = title;
            _tasks = new();
        }
        public ITask? FindTaskByTitle(string title)
        {
            return _tasks.Find(task => task.Title == title);
        }

        public void DeleteTaskByTitle(string title)
        {
            _tasks.RemoveAll(task => task.Title == title);
        }

        public void AddTask(ITask task)
        {
            if (FindTaskByTitle(task.Title) != null)
            {
                throw new System.Exception("Task already exists");
            }
            _tasks.Add(task);
        }

        public IReadOnlyCollection<ITask> FindTasks()
        {
            return _tasks;
        }
    }
}