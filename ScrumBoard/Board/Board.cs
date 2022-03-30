namespace ScrumBoard.Body
{
    public class Board : BoardInterface
    {
        public void Change_task_priority(string taskTitle, Task_priority newPriority) //Меняем приоритет задания
        {
            foreach (ColumnInterface column in _columns)
            {
                TaskInterface? task = column.Find_task_by_title(taskTitle);
                if (task != null)
                {
                    task.Priority = newPriority;
                    break;
                }
            }
        }
        public string Title { get; }

        public Board(string title)
        {
            Title = title;
            _columns = new();
        }

        public void Add_column(ColumnInterface column)
        {
            _columns.Add(column);
        }

        public IReadOnlyCollection<ColumnInterface> Find_columns()
        {
            return _columns;
        }

        public ColumnInterface? Find_column_by_title(string title)
        {
            return _columns.Find(column => column.Title == title);
        }

        public void Add_task_to_column(TaskInterface task, string? columnTitle = null)
        {
            if (columnTitle == null)
            {
                _columns[0].Add_task(task);
                return;
            }
            ColumnInterface? column = Find_column_by_title(columnTitle);
            column.Add_task(task);
        }
        public void Move_task(string taskTitle)
        {
            TaskInterface? task = null;
            int nextColumnIndex = 0;

            for (int i = 0; i < _columns.Count; ++i)
            {
                task = _columns[i].Find_task_by_title(taskTitle);
                if (task != null)
                {
                    _columns[i].Delete_task_by_title(taskTitle);
                    nextColumnIndex = i + 1;
                    break;
                }
            }

            if (nextColumnIndex != 0 && task != null)
            {
                _columns[nextColumnIndex].Add_task(task);
            }
        }
        public void Delete_task(string taskTitle)
        {
            foreach (ColumnInterface column in _columns)
            {
                column.Delete_task_by_title(taskTitle);
            }
        }

        public void Rename_column(string columnTitle, string newTitle)
        {
            ColumnInterface? column = Find_column_by_title(columnTitle);
            column.Title = newTitle;
        }

        public void Rename_task(string taskTitle, string newTitle)
        {
            foreach (ColumnInterface column in _columns)
            {
                TaskInterface? task = column.Find_task_by_title(taskTitle);
                if (task != null)
                {
                    task.Title = newTitle;
                    break;
                }
            }
        }

        public void Change_task_description(string taskTitle, string newDescription)
        {
            foreach (ColumnInterface column in _columns)
            {
                TaskInterface? task = column.Find_task_by_title(taskTitle);
                if (task != null)
                {
                    task.Description = newDescription;
                    break;
                }
            }
        }

        private const int MAX_COLUMNS = 10;
        private List<ColumnInterface> _columns;
    }
}