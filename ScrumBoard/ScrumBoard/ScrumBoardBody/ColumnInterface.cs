namespace ScrumBoard.Body
{
    public interface ColumnInterface
    {
        public string Title { get; set; }

        public void Add_task(TaskInterface task);
        public void Delete_task_by_title(string title);
        public TaskInterface? Find_task_by_title(string title);
        public IReadOnlyCollection<TaskInterface> Find_tasks();
    }
}
