using ScrumBoard.SpecialCases;

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
                    return;
                }
            }
            throw new Task_not_found();
        }
        public string Title { get; }
        public string ID { get; }

        public Board(string identifier, string title)
        {
            ID = identifier;
            Title = title;
            _columns = new();
        }

        public void Add_column(ColumnInterface column)
        {
            if (_columns.Count == MAX_COLUMNS)
            {
                throw new Maximum_columns();
            }
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
            if (column == null)
            {
                throw new Column_not_found();
            }
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
                    if (i == _columns.Count - 1)
                    {
                        throw new Final_column_achieved();
                    }
                    _columns[i].Delete_task_by_title(taskTitle);
                    nextColumnIndex = i + 1;
                    break;
                }
            }

            if (nextColumnIndex != 0 && task != null)
            {
                _columns[nextColumnIndex].Add_task(task);
                return;
            }
            throw new Task_not_found();
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
            if (column == null)
            {
                throw new Column_not_found();
            }
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
            throw new SpecialCases.Task_not_found();
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
            throw new Task_not_found();
        }

        private const int MAX_COLUMNS = 10;
        private List<ColumnInterface> _columns;
    }
}
