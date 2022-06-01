namespace ScrumBoard.Body
{
    public interface IBoard
    {
        public string Title { get; }
        public string ID { get; set; }

        public void DeleteTask(string taskTitle);
        public void RenameTask(string taskTitle, string newTitle);
        public void ChangeTaskDescription(string taskTitle, string newDescription);
        public void AddTaskToColumn(ITask task, string? columnTitle = null);
        public void ChangeTaskPriority(string taskTitle, Task_priority newPriority);
        public void MoveTask(string taskTitle);
        public void AddColumn(IColumn column);
        public void RenameColumn(string columnTitle, string newTitle);
        public IReadOnlyCollection<IColumn> FindColumns();
        public IColumn? FindColumnByTitle(string title);
    }
}