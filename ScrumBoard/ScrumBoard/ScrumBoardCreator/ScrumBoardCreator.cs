using ScrumBoard.Body;

namespace ScrumBoard.Creator
{
    public class ScrumBoardCreator
    {
        public static BoardInterface Create_board(string title) // Создание доски
        {
            return new Board(title);
        }

        public static ColumnInterface Create_column(string title) // Создание колонки
        {
            return new Column(title);
        }

        public static TaskInterface Create_task(string title, string description, Task_priority priority) // Создание задания
        {
            return new Body.Task(title, description, priority);
        }
    }
}