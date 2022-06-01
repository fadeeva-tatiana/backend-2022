using ScrumBoard.Body;

namespace ScrumBoard.Creator
{
    public class ScrumBoardCreator
    {
        public static IBoard CreateBoard(string title) // Создание доски
        {
            return new Board(title);
        }

        public static IColumn CreateColumn(string title) // Создание колонки
        {
            return new Column(title);
        }

        public static ITask CreateTask(string title, string description, Task_priority priority) // Создание задания
        {
            return new Body.Task(title, description, priority);
        }
    }
}