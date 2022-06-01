namespace ScrumBoard.Body
{
    public class Board : IBoard
    {
        private const int MAX_COLUMNS = 10;
        private List<IColumn> _columns;
        public Board(string title)
        {
            ID = Guid.NewGuid().ToString();
            Title = title;
            _columns = new();
        }

        public string Title { get; }
        public string ID { get; set; }

        public IReadOnlyCollection<IColumn> FindColumns()
        {
            return _columns;
        }

        public IColumn? FindColumnByTitle(string title)
        {
            return _columns.Find(column => column.Title == title);
        }

        public void ChangeTaskPriority(string taskTitle, Task_priority newPriority) //Меняем приоритет задания
        {
            foreach (IColumn column in _columns)
            {
                ITask? task = column.FindTaskByTitle(taskTitle);
                if (task != null)
                {
                    task.Priority = newPriority;
                    return;
                }
            }
            throw new System.Exception("Task not found");
        }

        public void AddColumn(IColumn column)
        {
            if (_columns.Count == MAX_COLUMNS)
            {
                throw new System.Exception("The number of columns on the board is exceeded, the maximum count of columns is 10");
            }
            if (FindColumnByTitle(column.Title) != null)
            {
                throw new System.Exception("Column already exists");
            }
            _columns.Add(column);
        }

        public void AddTaskToColumn(ITask task, string? columnTitle = null)
        {
            if (columnTitle == null)
            {
                _columns[0].AddTask(task);
                return;
            }
            IColumn? column = FindColumnByTitle(columnTitle);
            if (column == null)
            {
                throw new System.Exception("Column not found");
            }
            column.AddTask(task);
        }
        public void MoveTask(string taskTitle)
        {
            ITask? task = null;
            int nextColumnIndex = 0;

            for (int i = 0; i < _columns.Count; ++i)
            {
                task = _columns[i].FindTaskByTitle(taskTitle);
                if (task != null)
                {
                    if (i == _columns.Count - 1)
                    {
                        throw new System.Exception("Final column achieved");
                    }
                    _columns[i].DeleteTaskByTitle(taskTitle);
                    nextColumnIndex = i + 1;
                    break;
                }
            }

            if (nextColumnIndex != 0 && task != null)
            {
                _columns[nextColumnIndex].AddTask(task);
                return;
            }
            throw new System.Exception("Task not found");
        }
        public void DeleteTask(string taskTitle)
        {
            foreach (IColumn column in _columns)
            {
                column.DeleteTaskByTitle(taskTitle);
            }
        }

        public void RenameColumn(string columnTitle, string newTitle)
        {
            IColumn? column = FindColumnByTitle(columnTitle);
            if (column == null)
            {
                throw new System.Exception("Column not found");
            }
            column.Title = newTitle;
        }

        public void RenameTask(string taskTitle, string newTitle)
        {
            foreach (IColumn column in _columns)
            {
                ITask? task = column.FindTaskByTitle(taskTitle);
                if (task != null)
                {
                    task.Title = newTitle;
                    break;
                }
            }
            throw new System.Exception("Task not found");
        }

        public void ChangeTaskDescription(string taskTitle, string newDescription)
        {
            foreach (IColumn column in _columns)
            {
                ITask? task = column.FindTaskByTitle(taskTitle);
                if (task != null)
                {
                    task.Description = newDescription;
                    break;
                }
            }
            throw new System.Exception("Task not found");
        }
    }
}