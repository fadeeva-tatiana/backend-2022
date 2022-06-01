namespace ScrumBoard.Body
{
    public interface IColumn
    {
        public string Title { get; set; }
        public string ID { get; set; }

        public void AddTask(ITask task);
        public void DeleteTaskByTitle(string title);
        public ITask? FindTaskByTitle(string title);
        public IReadOnlyCollection<ITask> FindTasks();
    }
}